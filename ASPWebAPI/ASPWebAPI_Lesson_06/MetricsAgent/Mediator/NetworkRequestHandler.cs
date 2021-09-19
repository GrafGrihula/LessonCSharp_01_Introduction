﻿using AutoMapper;
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
    public class NetworkRequestHandler : IRequestHandler<NetworkMetricCreateRequest, List<NetworkMetricDto>>
    {
        private readonly INetworkMetricsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<NetworkRequestHandler> _logger;

        public NetworkRequestHandler(INetworkMetricsRepository repository,
                                 IMapper mapper,
                                 ILogger<NetworkRequestHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<NetworkMetricDto>> Handle(NetworkMetricCreateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Geting Network Metrics: from - {request.StartTime}, to - {request.StopTime}");

            var metrics = _repository.GetByTimePeriod(request.StartTime, request.StopTime);

            var response = new List<NetworkMetricDto>();

            foreach(var metric in metrics)
            {
                response.Add(_mapper.Map<NetworkMetricDto>(metric));
            }
            return Task.FromResult(response);
        }
    }
}