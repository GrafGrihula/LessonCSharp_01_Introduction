using MetricsAgent.DAL.Models;
using System.Collections.Generic;

namespace MetricsManager.Client.Responses
{
    public class DotNetMetricsApiResponse
    {
        public List<DotNetMetric> Metrics { get; set; }
    }
}
