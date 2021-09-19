using AutoMapper;
using MediatR;
using MetricsAgent.Controllers.Models;
using MetricsAgent.Controllers.Requests;
using MetricsAgent.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MetricsAgent.Mediator
{
    public class CpuRequestHandler : IRequestHandler<CpuMetricCreateRequest, List<CpuMetricDto>>
    {
        private readonly ICpuMetricsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CpuRequestHandler> _logger;

        public CpuRequestHandler(ICpuMetricsRepository repository,
                                 IMapper mapper,
                                 ILogger<CpuRequestHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<CpuMetricDto>> Handle(CpuMetricCreateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Geting Cpu Metrics: from - {request.StartTime}, to - {request.StopTime}");

            var metrics = _repository.GetByTimePeriod(request.StartTime, request.StopTime);

            var response = new List<CpuMetricDto>();

            foreach(var metric in metrics)
            {
                response.Add(_mapper.Map<CpuMetricDto>(metric));
            }
            return Task.FromResult(response);
        }
    }
}
