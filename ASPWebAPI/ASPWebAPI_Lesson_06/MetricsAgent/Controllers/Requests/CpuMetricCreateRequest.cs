﻿using MediatR;
using MetricsAgent.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Controllers.Requests
{
    public class CpuMetricCreateRequest : IRequest<List<CpuMetricDto>>
    {
        [FromRoute]
        public DateTimeOffset StartTime { get; set; }
        [FromRoute]
        public DateTimeOffset StopTime { get; set; }
    }
}