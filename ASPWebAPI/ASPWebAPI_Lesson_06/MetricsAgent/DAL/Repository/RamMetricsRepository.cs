using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL.Repository
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private readonly IDBConnectionManager _connection;

        public RamMetricsRepository(IDBConnectionManager connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }


        public void Create(RamMetric item)
        {
            using var connection = _connection.CreateOpenedConnection();

            connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }


        public IList<RamMetric> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE time BETWEEN @startTime AND @stopTime",
                new
                {
                    startTime = startTime.ToUnixTimeSeconds(),
                    stopTime = stopTime.ToUnixTimeSeconds()
                }).ToList();
        }
    }
}
