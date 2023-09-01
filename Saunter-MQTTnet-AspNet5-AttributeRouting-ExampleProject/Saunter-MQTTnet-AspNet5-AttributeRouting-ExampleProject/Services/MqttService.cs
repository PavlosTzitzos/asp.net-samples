#region Using Imports

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.AspNetCore.AttributeRouting;
using MQTTnet.Client.Receiving;
using MQTTnet.Server;
using Saunter.Attributes;
using Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Models;

#endregion Using Imports

namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Services
{
    [AsyncApi] // Tells Saunter to scan the Service
    public class MqttService :
        IMqttServerConnectionValidator,
        IMqttApplicationMessageReceivedHandler,
        IMqttServerApplicationMessageInterceptor,
        IMqttServerStartedHandler,
        IMqttServerStoppedHandler,
        IMqttServerClientConnectedHandler,
        IMqttServerClientDisconnectedHandler,
        IMqttServerClientSubscribedTopicHandler,
        IMqttServerClientUnsubscribedTopicHandler
    {
        #region MQTT Service & Server Configuration

        #region Variable Declarations
        
        // Default Variable Initialization
        private readonly AppSettings _appSettings;
        private readonly ILogger<MqttService> _logger;
        private static readonly string _newLine = Environment.NewLine;
        public IMqttServer Server;
        public List<string> connectedClientIds = new();
        
        private const string Prefix = nameof(MqttService) + "/"; // Defines the Route Prefix for the Topics
        private const string Sub = "subscribe/";

        // Saunter Subscribe topics
        private const string SaunterSubKiss = Prefix + Sub + "kiss";

        #endregion Variable Declarations
        
        public MqttService(AppSettings appSettings, ILogger<MqttService> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }
        
        public void ConfigureMqttServerOptions(AspNetMqttServerOptionsBuilder options)
        {
            // Configure the MQTT Server options here
            options.WithoutDefaultEndpoint();
            options.WithConnectionValidator(this);
            options.WithApplicationMessageInterceptor(this);
            // Enable Attribute Routing
            // By default, messages published to topics that don't match any routes are rejected. 
            // Change this to true to allow those messages to be routed without hitting any controller actions.
            options.WithAttributeRouting(true);
        }

        public void ConfigureMqttServer(IMqttServer mqtt)
        {
            Server = mqtt;
            mqtt.ApplicationMessageReceivedHandler = this;
            mqtt.StartedHandler = this;
            mqtt.StoppedHandler = this;
            mqtt.ClientConnectedHandler = this;
            mqtt.ClientDisconnectedHandler = this;
            mqtt.ClientSubscribedTopicHandler = this;
            mqtt.ClientUnsubscribedTopicHandler = this;
        }

        #endregion MQTT Service & Server Configuration

        #region Validation & Interception

        public Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            return Task.Run(() => { Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "ValidateConnectionAsync Handler Triggered"); });
        }

        public Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(
                    $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - Received MQTT Message Logged:{_newLine}" +
                    $"- Topic = {eventArgs.ApplicationMessage.Topic + _newLine}" +
                    $"- Payload = {Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload) + _newLine}" +
                    $"- QoS = {eventArgs.ApplicationMessage.QualityOfServiceLevel + _newLine}" +
                    $"- Retain = {eventArgs.ApplicationMessage.Retain + _newLine}");
            });
        }

        public Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
        {
            return Task.Run(() => { Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "InterceptApplicationMessagePublishAsync Handler Triggered"); });
        }

        #endregion Validation & Interception

        #region Handle Server Actions

        public Task HandleServerStartedAsync(EventArgs eventArgs)
        {
            return Task.Run(() => { Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "HandleServerStartedAsync Handler Triggered"); });
            
        }

        public Task HandleServerStoppedAsync(EventArgs eventArgs)
        {
            return Task.Run(() => { Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "HandleServerStoppedAsync Handler Triggered"); });
        }

        #endregion Handle Server Actions

        #region Handle Client Actions

        public Task HandleClientConnectedAsync(MqttServerClientConnectedEventArgs eventArgs)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                  "HandleClientConnectedAsync Handler Triggered");
                
                if(connectedClientIds.Count == 0)
                    SubscribeKiss();
                
                var clientId = eventArgs.ClientId;
                connectedClientIds.Add(clientId);
                
                Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                  $"MQTT Client Connected:{_newLine} - ClientID = {clientId + _newLine}");
            });
        }

        public Task HandleClientDisconnectedAsync(MqttServerClientDisconnectedEventArgs eventArgs)
        {
            return Task.Run(() => { 
                Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "HandleClientDisconnectedAsync Handler Triggered");
                
                var clientId = eventArgs.ClientId;
                connectedClientIds.Remove(clientId);
                
                Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                  $"MQTT Client Disconnected:{_newLine} - ClientID = {clientId + _newLine}");
            });
        }

        public Task HandleClientSubscribedTopicAsync(MqttServerClientSubscribedTopicEventArgs eventArgs)
        {
            return Task.Run(() => { Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "ClientSubscribedTopicHandler Handler Triggered"); });
        }

        public Task HandleClientUnsubscribedTopicAsync(MqttServerClientUnsubscribedTopicEventArgs eventArgs)
        {
            return Task.Run(() => { Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - " +
                                                      "ClientSubscribedTopicHandler Handler Triggered"); });
        }

        #endregion Handle Client Actions

        #region Subscribe Topics
        
        [Channel(SaunterSubKiss)] // Create a Channel & Generate AsyncAPI Documentation
        [SubscribeOperation(typeof(void),
            Summary = "Subscribes to the 'Kiss' Topic. Which will publish a message every X seconds " +
                      "to confirm that the MQTTnet Server is still running correctly.")]
        public void SubscribeKiss()
        {
            Task.Run(async () =>
            {
                var frameworkName =
                    GetType().Assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

                var msg = new MqttApplicationMessageBuilder()
                    .WithPayload($"MQTTnet hosted on {frameworkName} has started up!").WithTopic(SaunterSubKiss);

                while (connectedClientIds.Count > 0)
                    try
                    {
                        await Server.PublishAsync(msg.Build());
                        msg.WithPayload($"MQTTnet hosted on {frameworkName} is still running at {DateTime.Now}!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        await Task.Delay(TimeSpan.FromSeconds(_appSettings.KissIntervalSeconds));
                    }
            });
        }
        
        #endregion Subscribe Topics
    }
}