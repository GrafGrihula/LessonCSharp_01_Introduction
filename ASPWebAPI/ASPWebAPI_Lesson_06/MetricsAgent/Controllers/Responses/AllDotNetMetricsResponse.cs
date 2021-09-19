using MetricsAgent.Controllers.Models;
using System.Collections.Generic;

namespace MetricsAgent.Controllers.Responses
{
    public class AllDotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }
}
