using Microsoft.AspNetCore.Mvc;
using MQTTnet.AspNetCore.AttributeRouting;

namespace WebApi.MqttControllers
{
    [MqttController]
    public class CatchAllController : MqttBaseController
    {
        private readonly ILogger<CatchAllController> _logger;

        // Controllers have full support for dependency injection just like AspNetCore controllers
        public CatchAllController(ILogger<CatchAllController> logger)
        {
            _logger = logger;
        }

        [MqttRoute("{*topic}")]
        public Task WeatherReport(string topic)
        {
            // We have access to the MqttContext
            _logger.LogInformation($"Wildcard match on topic {topic}");

            return Ok();
        }
    }
}
