using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Requests
{
    public class BaseApiRequest
    {
        public Uri AgentUrl { get; set; }
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }
    }
}
