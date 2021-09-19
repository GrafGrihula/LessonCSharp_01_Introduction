using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerTests
    {
        private readonly RamMetricsController controller;

        public RamMetricsControllerTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var startTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var stopTime = DateTimeOffset.FromUnixTimeSeconds(100);

            //Act
            var result = controller.GetMetricsFromAgent(agentId, startTime, stopTime);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
