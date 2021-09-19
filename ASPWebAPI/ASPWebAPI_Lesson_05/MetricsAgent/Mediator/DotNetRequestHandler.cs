using AutoMapper;
using MediatR;
using MetricsAgent.Controllers.Models;
using MetricsAgent.Controllers.Requests;
using MetricsAgent.DAL;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MetricsAgent.Mediator
{
    public class DotNetRequestHandler : IRequestHandler<DotNetMetricCreateRequest, List<DotNetMetricDto>>
    {
        private readonly IDotNetMetricsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DotNetRequestHandler> _logger;

        public DotNetRequestHandler(IDotNetMetricsRepository repository,
                                 IMapper mapper,
                                 ILogger<DotNetRequestHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<DotNetMetricDto>> Handle(DotNetMetricCreateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Geting DotNet Metrics: from - {request.StartTime}, to - {request.StopTime}");

            var metrics = _repository.GetByTimePeriod(request.StartTime, request.StopTime);

            var response = new List<DotNetMetricDto>();

            foreach(var metric in metrics)
            {
                response.Add(_mapper.Map<DotNetMetricDto>(metric));
            }
            return Task.FromResult(response);
        }
    }
}
