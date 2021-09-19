using AutoMapper;
using MetricsAgent.Controllers.Models;
using MetricsAgent.DAL.Models;
using System;

namespace MetricsAgent.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();
            CreateMap<long, DateTimeOffset>().ConvertUsing(new DateTimeOffsetConverter());
        }
    }
}
