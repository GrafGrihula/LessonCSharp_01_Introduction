using Dapper;
using MetricsAgent.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.DAL.Repository
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private readonly IDBConnectionManager _connection;

        public HddMetricsRepository(IDBConnectionManager connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }


        public void Create(HddMetric item)
        {
            using var connection = _connection.CreateOpenedConnection();

            connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time
                });
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(HddMetric item)
        {
            throw new NotImplementedException();
        }

        public IList<HddMetric> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<HddMetric>("SELECT * FROM hddmetrics WHERE time BETWEEN @startTime AND @stopTime",
                new
                {
                    startTime = startTime.ToUnixTimeSeconds(),
                    stopTime = stopTime.ToUnixTimeSeconds()
                }).ToList();
        }
    }
}
