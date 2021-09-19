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
    public class RamRequestHandler : IRequestHandler<RamMetricCreateRequest, List<RamMetricDto>>
    {
        private readonly IRamMetricsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<RamRequestHandler> _logger;

        public RamRequestHandler(IRamMetricsRepository repository,
                                 IMapper mapper,
                                 ILogger<RamRequestHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<RamMetricDto>> Handle(RamMetricCreateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Geting Ram Metrics: from - {request.StartTime}, to - {request.StopTime}");

            var metrics = _repository.GetByTimePeriod(request.StartTime, request.StopTime);

            var response = new List<RamMetricDto>();

            foreach(var metric in metrics)
            {
                response.Add(_mapper.Map<RamMetricDto>(metric));
            }
            return Task.FromResult(response);
        }
    }
}
