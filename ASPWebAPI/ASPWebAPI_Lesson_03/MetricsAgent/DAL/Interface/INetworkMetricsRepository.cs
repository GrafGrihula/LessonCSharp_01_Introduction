using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    // маркировочный интерфейс
    // необходим, чтобы проверить работу репозитория на тесте-заглушке
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>
    {
    }
}
