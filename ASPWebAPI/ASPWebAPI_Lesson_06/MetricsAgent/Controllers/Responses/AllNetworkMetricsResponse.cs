using MetricsAgent.Controllers.Models;
using System.Collections.Generic;

namespace MetricsAgent.Controllers.Responses
{
    public class AllNetworkMetricsResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }
}
