using System.Data;

namespace MetricsAgent.DAL
{
    public interface IDBConnectionManager
    {
        IDbConnection CreateOpenedConnection();
    }
}
