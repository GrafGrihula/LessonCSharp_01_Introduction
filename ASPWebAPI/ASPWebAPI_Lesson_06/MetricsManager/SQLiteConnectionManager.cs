using MetricsManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class SQLiteConnectionManager : IDBConnectionManager
    {
        public string ConnectionString => "Data Source=metricsManager.db;Version=3;Pooling=true;Max Pool Size=100";
        public IDbConnection CreateOpenedConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            return connection;
        }
    }
}
