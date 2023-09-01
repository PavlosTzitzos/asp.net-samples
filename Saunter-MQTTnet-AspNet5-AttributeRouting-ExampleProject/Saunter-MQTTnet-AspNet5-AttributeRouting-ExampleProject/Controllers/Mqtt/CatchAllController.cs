#region Using Imports

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MQTTnet.AspNetCore.AttributeRouting;
using Saunter.Attributes;

#endregion Using Imports

namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Controllers.Mqtt
{
    [AsyncApi] // Tells Saunter to scan the Controller
    [MqttController] // Generate MQTT Attribute Routing for the Controller 
    public class CatchAllController : MqttBaseController // Inherit from MqttBaseController for convenience functions
    {
        #region Variable Declarations

        // Default Variable Initialization
        private readonly ILogger<CatchAllController> _logger;

        // MQTTnet Publish topics
        private const string MqttNetCatchAll = "{*topic}";
        
        // Saunter Publish topics
        private const string SaunterCatchAll = "#";
        
        #endregion Variable Declarations

        // Initialize the MQTT Controller with full dependency injection support (Like normal AspNetCore controllers)
        public CatchAllController(ILogger<CatchAllController> logger)
        {
            _logger = logger;
        }

        [MqttRoute(MqttNetCatchAll)] // Generate MQTT Attribute Routing for this Topic
        [Channel(SaunterCatchAll)] // Create a Channel & Generate AsyncAPI Documentation
        [PublishOperation(typeof(string), Summary = "Catches all Publishes done to the MQTTnet Broker.")]
        public Task WildCardMatchTopic(string topic)
        {
            // We have access to the MqttContext
            _logger.LogInformation($"Catch All Controller - Wildcard matched on Topic: '{topic}'");

            return Ok();
        }
    }
}