using AutoMapper;
using MetricsManager.Client.Models;
using MetricsManager.Client.Responses;
using MetricsManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AgentInfo, Agent>();
            CreateMap<Agent, AgentInfo>();


            CreateMap<CpuMetrics, CpuMetric>();
            CreateMap<CpuMetric, CpuMetrics>();
            CreateMap<CpuMetrics, CpuMetricsApiResponse>();
            CreateMap<CpuMetricsApiResponse, CpuMetrics>();

            CreateMap<DotNetMetrics, DotNetMetric>();
            CreateMap<DotNetMetric, DotNetMetrics>();
            CreateMap<DotNetMetrics, DotNetMetricsApiResponse>();
            CreateMap<DotNetMetricsApiResponse, DotNetMetrics>();


            CreateMap<long, DateTimeOffset>().ConvertUsing(new LongToDateTimeOffsetConverter());
            CreateMap<DateTimeOffset, long>().ConvertUsing(new DateTimeOffsetToLongConverter());
        }
    }
}
