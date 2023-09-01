#region Using Imports

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MQTTnet.AspNetCore.AttributeRouting;
using Saunter.Attributes;
using Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Models;
using Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Services;

#endregion Using Imports

namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Controllers.Mqtt
{
    [AsyncApi] // Tells Saunter to scan the Controller
    [MqttController] // Generate MQTT Attribute Routing for the Controller
    [MqttRoute(nameof(ExampleController))] // Defines the Route Prefix for the Controller
    public class ExampleController : MqttBaseController // Inherit from MqttBaseController for convenience functions
    {
        #region Variable Declarations

        // Default Variable Initialization
        private readonly AppSettings _appSettings;
        private readonly ILogger<ExampleController> _logger;
        private readonly MqttService _mqttService;
        
        private const string Prefix = nameof(ExampleController) + "/"; // Defines the Route Prefix for the Topics
        private const string Pub = "publish/";

        // MQTTnet Publish topics
        private const string MqttNetPubTest = Pub + "test";
        private const string MqttNetPubWeatherReport = Pub + "{zipCode:int}/temperature";
        
        // Saunter Publish topics
        private const string SaunterPubTest = Prefix + Pub + "test";
        private const string SaunterPubWeatherReport = Prefix + Pub + "+/temperature";

        #endregion Variable Declarations
        
        // Initialize the MQTT Controller with full dependency injection support (Like normal AspNetCore controllers)
        public ExampleController(AppSettings appSettings, ILogger<ExampleController> logger, MqttService mqttService)
        {
            _appSettings = appSettings;
            _logger = logger;
            _mqttService = mqttService;
        }

        #region Publish Topics

        [MqttRoute(MqttNetPubTest)] // Generate MQTT Attribute Routing for this Topic
        [Channel(SaunterPubTest)] // Create a Channel & Generate AsyncAPI Documentation
        [PublishOperation(typeof(string), 
            Summary = "Publishes a 'Test' Payload to the '" + SaunterPubTest + "' Topic.")]
        public Task PublishTest()
        {
            var payloadMessage = BitConverter.ToString(Message.Payload);
            _logger.LogInformation("Test Payload Received! Payload String Content: " + Message.Payload);
            return Ok();
        }

        [MqttRoute(MqttNetPubWeatherReport)] // Generate MQTT Attribute Routing for this Topic
        [Channel(SaunterPubWeatherReport)] // Create a Channel & Generate AsyncAPI Documentation
        [PublishOperation(typeof(int), 
            Summary = "Publishes a 'WeatherReport' Payload to the '" + SaunterPubWeatherReport + "' Topic.")]
        public Task PublishWeatherReport(int zipCode)
        {
            // We have access to the MqttContext
            if (zipCode != 90210) MqttContext.CloseConnection = true;

            // We have access to the raw message
            var temperature = int.Parse(Encoding.ASCII.GetString(Message.Payload));
            _logger.LogInformation($"It's {temperature} degrees in Hollywood");

            // Example validation
            return temperature is <= 0 or >= 130 ? BadMessage() : Ok();
        }

        #endregion Publish Topics
    }
}