using MediatR;
using MetricsAgent.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HddMetricsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetrics([FromRoute] HddMetricCreateRequest metricCreateRequest)
        {
            return Ok(_mediator.Send(metricCreateRequest).Result);
        }
    }
}
