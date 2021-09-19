using MediatR;
using MetricsAgent.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RamMetricsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetrics([FromRoute] RamMetricCreateRequest metricCreateRequest)
        {
            return Ok(_mediator.Send(metricCreateRequest).Result);
        }
    }
}
