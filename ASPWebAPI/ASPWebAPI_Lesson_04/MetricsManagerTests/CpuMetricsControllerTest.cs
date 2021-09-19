using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuControllerUnitTests
    {
        private readonly CpuMetricsController _controller;

        public CpuControllerUnitTests()
        {
            _controller = new CpuMetricsController();
        }


        [Fact]
        public void GetMetricsFromAgentReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTimeOffset.FromUnixTimeSeconds( 0 );
            var toTime = DateTimeOffset.FromUnixTimeSeconds( 100 );

            //Act
            var result = _controller.GetMetricsFromAgent( agentId, fromTime, toTime );

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>( result );
        }


        [Fact]
        public void GetMetricsFromAllClusterReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            //Act
            var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
