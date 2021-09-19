using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL.Repository
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        private readonly IDBConnectionManager _connection;

        public DotNetMetricsRepository(IDBConnectionManager connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }


        public void Create(DotNetMetric item)
        {
            using var connection = _connection.CreateOpenedConnection();

            connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }


        public IList<DotNetMetric> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<DotNetMetric>("SELECT * FROM dotnetmetrics WHERE time BETWEEN @startTime AND @stopTime",
                new
                {
                    startTime = startTime.ToUnixTimeSeconds(),
                    stopTime = stopTime.ToUnixTimeSeconds()
                }).ToList();
        }
    }
}
