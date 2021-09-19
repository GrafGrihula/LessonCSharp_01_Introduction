using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL.Repository
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private readonly IDBConnectionManager _connection;

        public CpuMetricsRepository(IDBConnectionManager connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }


        public void Create(CpuMetric item)
        {
            using var connection = _connection.CreateOpenedConnection();

            connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }


        public IList<CpuMetric> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE time BETWEEN @startTime AND @stopTime",
                new
                {
                    startTime = startTime.ToUnixTimeSeconds(),
                    stopTime = stopTime.ToUnixTimeSeconds()
                }).ToList();
        }
    }
}
