using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTest
{
    public class NetworkMetricsControllerTest
    {
        private readonly NetworkMetricsController controller;

        public NetworkMetricsControllerTest()
        {
            controller = new NetworkMetricsController();
        }


        [Fact]
        public void GetMetricsToManagerReturnsOk()
        {
            //Arrange
            var fromTime = DateTimeOffset.FromUnixTimeSeconds(0);
            var toTime = DateTimeOffset.FromUnixTimeSeconds(100);

            //Act
            var result = controller.GetMetricsToManager(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
