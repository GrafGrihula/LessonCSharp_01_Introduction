using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsController> _logger;

        public NetworkMetricsController()
        {
        }

        public NetworkMetricsController(ILogger<NetworkMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в NetworkMetricsController");
        }



        [HttpGet]
        public IActionResult GetHi()
        {
            return Ok("Hi!");
        }


        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог");
            //return Ok();
            return Ok($"agent/{agentId}/from/{fromTime}/to/{toTime}");
        }


        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster(
            [FromRoute] DateTimeOffset fromTime,
            [FromRoute] DateTimeOffset toTime)
        {
            return Ok($"cluster/from/{fromTime}/to/{toTime}");
        }
    }
}
