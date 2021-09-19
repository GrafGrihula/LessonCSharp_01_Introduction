using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerTest
    {
        private readonly RamMetricsController controller;

        public RamMetricsControllerTest()
        {
            controller = new RamMetricsController();
        }


        [Fact]
        public void GetMetricsFromAgentReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            //Act
            var result = controller.GetMetricsFromAgent( agentId, fromTime, toTime );

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
            var result = controller.GetMetricsFromAllCluster(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}