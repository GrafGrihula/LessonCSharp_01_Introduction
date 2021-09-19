using System;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllDotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }


    public class DotNetMetricDto
    {
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
    }
}
