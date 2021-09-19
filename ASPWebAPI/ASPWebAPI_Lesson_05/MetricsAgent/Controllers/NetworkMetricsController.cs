using MediatR;
using MetricsAgent.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NetworkMetricsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("from/{startTime}/to/{stopTime}")]
        public IActionResult GetMetrics([FromRoute] NetworkMetricCreateRequest metricCreateRequest)
        {
            return Ok(_mediator.Send(metricCreateRequest).Result);
        }
    }
}
