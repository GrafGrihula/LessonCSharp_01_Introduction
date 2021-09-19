using MetricsAgent.DAL.Models;
using System.Collections.Generic;

namespace MetricsManager.Client.Responses
{
    public class HddMetricsApiResponse
    {
        public List<HddMetric> Metrics { get; set; }
    }
}
