using MetricsManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetByTimePeriodFromAgent(AgentIdTimePeriod period);
        IList<T> GetByTimePeriod(TimePeriod period);
        DateTimeOffset GetLastDate(int agentId);
        void Create(T item);
    }
}
