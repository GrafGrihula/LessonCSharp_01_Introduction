﻿using MetricsManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Responses
{
    public class CpuMetricsApiResponse
    {
        public List<CpuMetric> Metrics { get; set; }
    }
}
