using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL.Repository
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private readonly IDBConnectionManager _connection;

        public NetworkMetricsRepository(IDBConnectionManager connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }


        public void Create(NetworkMetric item)
        {
            using var connection = _connection.CreateOpenedConnection();

            connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }


        public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<NetworkMetric>("SELECT * FROM networkmetrics WHERE time BETWEEN @startTime AND @stopTime",
                new
                {
                    startTime = startTime.ToUnixTimeSeconds(),
                    stopTime = stopTime.ToUnixTimeSeconds()
                }).ToList();
        }
    }
}
