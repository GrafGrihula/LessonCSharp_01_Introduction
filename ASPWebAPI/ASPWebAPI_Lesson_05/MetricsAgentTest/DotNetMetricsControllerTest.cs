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
    public class DotNetMetricsControllerTests
    {
        private readonly Mock<ILogger<DotNetRequestHandler>> _mockLogger;
        private readonly Mock<IDotNetMetricsRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly DotNetMetricCreateRequest _metricCreateRequest;
        private readonly DotNetRequestHandler _handler;

        public DotNetMetricsControllerTests()
        {
            _mockLogger = new Mock<ILogger<DotNetRequestHandler>>();
            _mockRepository = new Mock<IDotNetMetricsRepository>();
            _mockMapper = new Mock<IMapper>();
            _metricCreateRequest = new DotNetMetricCreateRequest
            {
                StartTime = DateTimeOffset.FromUnixTimeSeconds(0),
                StopTime = DateTimeOffset.FromUnixTimeSeconds(100)
            };
            _handler = new DotNetRequestHandler(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetMetricst_ReturnOk()
        {
            //Arrange
            _mockRepository.Setup(repository =>
                repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<DotNetMetric>()).Verifiable();

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
