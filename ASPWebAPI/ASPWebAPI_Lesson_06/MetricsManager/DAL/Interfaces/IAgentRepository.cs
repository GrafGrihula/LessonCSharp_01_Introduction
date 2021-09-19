using MetricsManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    public interface IAgentRepository
    {
        IList<Agent> GetAllAgents();
        void RegisterAgent(Agent agent);
        void RemoveAgent(int id);
        void EnableAgent(int id);
        void DisableAgent(int id);
    }
}
