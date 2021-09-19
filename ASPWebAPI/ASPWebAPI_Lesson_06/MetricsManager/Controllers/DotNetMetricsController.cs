using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        [HttpGet("agent/{agentId}/from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTimeOffset startTime,
            [FromRoute] DateTimeOffset stopTime)
        {
            return Ok();
        }
    }
}
