using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        //private ILogger<CpuMetricsController> _logger;

        //public CpuMetricsController(ILogger<CpuMetricsController> logger)
        //{
        //    _logger = logger;
        //}

        public CpuMetricsController()
        {
        }

        [HttpGet("agent/{agentId}/from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset startTime,
            [FromRoute] DateTimeOffset stopTime)
        {
            return Ok($"agentId: {agentId}, startTime: {startTime}, stopTime: {stopTime}");
        }

        //[HttpGet("agent/{agentId}/from/{startTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent(
        //    [FromRoute] int agentId, 
        //    [FromRoute] DateTimeOffset startTime, 
        //    [FromRoute] DateTimeOffset stopTime)
        //{

        //    _logger.LogInformation($"agentId {agentId}, startTime {startTime}, stopTime {stopTime}");
        //    return Ok($"agentId: {agentId}, startTime: {startTime}, stopTime: {stopTime}");
        //}

        [HttpGet("cluster/from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetricsFromCluster(
            [FromRoute] DateTimeOffset startTime, 
            [FromRoute] DateTimeOffset stopTime)
        {
            return Ok($"startTime: {startTime}, stopTime: {stopTime}");
        }


        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            return Ok($"agentId: {agentId}");
        }

        [HttpGet("cluster")]
        public IActionResult GetMetricsFromCluster()
        {
            return Ok();
        }

    }
}
