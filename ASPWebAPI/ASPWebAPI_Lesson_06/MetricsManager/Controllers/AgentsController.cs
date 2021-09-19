using AutoMapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;
        public AgentsController(IAgentRepository agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        public AgentsController()
        {
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _agentRepository.RegisterAgent(_mapper.Map<Agent>(agentInfo));

            return Ok();
        }


        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
        [HttpGet("get")]
        public IActionResult GetAgentsList()
        {
            return Ok();
        }
    }
}
