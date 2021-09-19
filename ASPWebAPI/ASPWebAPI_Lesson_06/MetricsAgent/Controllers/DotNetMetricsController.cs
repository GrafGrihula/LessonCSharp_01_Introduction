using MediatR;
using MetricsAgent.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DotNetMetricsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetrics([FromRoute] DotNetMetricCreateRequest metricCreateRequest)
        {
            return Ok(_mediator.Send(metricCreateRequest).Result);
        }
    }
}
