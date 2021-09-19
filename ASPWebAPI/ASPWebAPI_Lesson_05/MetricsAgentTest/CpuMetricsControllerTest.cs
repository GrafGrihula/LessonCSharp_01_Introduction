using AutoMapper;
using MetricsAgent.Controllers.Requests;
using MetricsAgent.DAL;
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
    public class CpuMetricsControllerTests
    {
        private readonly Mock<ILogger<CpuRequestHandler>> _mockLogger;
        private readonly Mock<ICpuMetricsRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CpuMetricCreateRequest _metricCreateRequest;
        private readonly CpuRequestHandler _handler;

        public CpuMetricsControllerTests()
        {
            _mockLogger = new Mock<ILogger<CpuRequestHandler>>();
            _mockRepository = new Mock<ICpuMetricsRepository>();
            _mockMapper = new Mock<IMapper>();
            _metricCreateRequest = new CpuMetricCreateRequest
            {
                StartTime = DateTimeOffset.FromUnixTimeSeconds(0),
                StopTime = DateTimeOffset.FromUnixTimeSeconds(100)
            };
            _handler = new CpuRequestHandler(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetMetricst_ReturnOk()
        {
            //Arrange
            _mockRepository.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<CpuMetric>()).Verifiable();

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
