using System;

namespace MetricsManager
{
    public class AgentInfo
    {
        public AgentInfo(int v, Uri uri)
        {
        }

        public int AgentId { get; set; }
        public string AgentUrl { get; set; }
        public bool Enabled { get; set; }
    }
}
