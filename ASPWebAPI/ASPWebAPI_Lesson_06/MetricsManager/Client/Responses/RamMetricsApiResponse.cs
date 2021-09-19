using MetricsAgent.DAL.Models;
using System.Collections.Generic;

namespace MetricsManager.Client.Responses
{
    public class RamMetricsApiResponse
    {
        public List<RamMetric> Metrics { get; set; }
    }
}
