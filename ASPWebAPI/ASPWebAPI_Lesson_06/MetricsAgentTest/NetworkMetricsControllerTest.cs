using AutoMapper;
using MetricsAgent.Controllers.Requests;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.Mediator;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerTests
    {
        private readonly Mock<ILogger<NetworkRequestHandler>> _mockLogger;
        private readonly Mock<INetworkMetricsRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly NetworkMetricCreateRequest _metricCreateRequest;
        private readonly NetworkRequestHandler _handler;

        public NetworkMetricsControllerTests()
        {
            _mockLogger = new Mock<ILogger<NetworkRequestHandler>>();
            _mockRepository = new Mock<INetworkMetricsRepository>();
            _mockMapper = new Mock<IMapper>();
            _metricCreateRequest = new NetworkMetricCreateRequest
            {
                StartTime = DateTimeOffset.FromUnixTimeSeconds(0),
                StopTime = DateTimeOffset.FromUnixTimeSeconds(100)
            };
            _handler = new NetworkRequestHandler(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetMetricst_ReturnOk()
        {
            //Arrange
            _mockRepository.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<NetworkMetric>()).Verifiable();

            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            //Act
            var result = _handler.Handle(_metricCreateRequest, CancellationToken.None);

            //Assert
            _mockRepository.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }
}
