using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTest
{
    public class HddMetricsControllerTest
    {
        private readonly HddMetricsController controller;

        public HddMetricsControllerTest()
        {
            controller = new HddMetricsController();
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
