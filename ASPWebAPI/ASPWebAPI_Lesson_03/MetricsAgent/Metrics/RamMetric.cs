using System;

namespace MetricsAgent
{
    public class RamMetric
    {
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        //public long Time { get; set; }
    }
}
