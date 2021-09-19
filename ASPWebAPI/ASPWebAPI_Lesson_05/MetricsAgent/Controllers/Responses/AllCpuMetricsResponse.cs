using MetricsAgent.Controllers.Models;
using System.Collections.Generic;

namespace MetricsAgent.Controllers.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
