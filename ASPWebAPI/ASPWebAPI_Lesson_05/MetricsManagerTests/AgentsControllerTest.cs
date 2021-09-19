using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerTests
    {
        private readonly AgentsController controller;

        public AgentsControllerTests()
        {
            controller = new AgentsController();
        }


        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            //Arrange
            var agentInfo = new AgentInfo(1, new Uri("http://adress"));

            //Act
            var result = controller.RegisterAgent(agentInfo);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = controller.EnableAgentById(agentId);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = controller.DisableAgentById(agentId);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetAgentsList_ReturnsOk()
        {
            //Act
            var result = controller.GetAgentsList();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}