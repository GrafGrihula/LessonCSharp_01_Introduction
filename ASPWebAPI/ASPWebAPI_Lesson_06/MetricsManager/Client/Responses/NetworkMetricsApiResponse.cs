using MetricsAgent.DAL.Models;
using System.Collections.Generic;

namespace MetricsManager.Client.Responses
{
    public class NetworkMetricsApiResponse
    {
        public List<NetworkMetric> Metrics { get; set; }
    }
}
