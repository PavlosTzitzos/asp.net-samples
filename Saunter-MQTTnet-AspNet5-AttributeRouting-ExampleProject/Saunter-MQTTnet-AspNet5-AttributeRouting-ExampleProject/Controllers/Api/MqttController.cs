#region Using Imports

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Server;

#endregion Using Imports

namespace Saunter_MQTTnet_AspNet5_AttributeRouting_ExampleProject.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MqttController : ControllerBase
    {
        private readonly ILogger<MqttController> _logger;
        private readonly IMqttServer _mqttServer;

        public MqttController(ILogger<MqttController> logger, IMqttServer mqttServer)
        {
            _logger = logger;
            _mqttServer = mqttServer;
        }

        [HttpGet]
        [Route("ServerStatus")]
        public IActionResult ServerStatus()
        {
            return Ok(_mqttServer.IsStarted);
        }

        [HttpPost]
        [Route("Publish")]
        public async Task<IActionResult> Publish([FromBody] [Required] MqttApplicationMessage payload)
        {
            try
            {
                await _mqttServer.PublishAsync(payload);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok();
        }
    }
}