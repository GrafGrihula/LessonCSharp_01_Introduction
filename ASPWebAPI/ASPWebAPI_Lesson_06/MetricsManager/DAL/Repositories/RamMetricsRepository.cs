﻿using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Repositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private readonly IDBConnectionManager _connection;

        public RamMetricsRepository(IDBConnectionManager connection)
        {
            _connection = connection;
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void Create(RamMetrics item)
        {
            using var connection = _connection.CreateOpenedConnection();

            connection.Execute("INSERT INTO rammetrics(value, time, agentId) VALUES(@value, @time, @agentId)",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    agentId = item.AgentId
                });
        }

        public IList<RamMetrics> GetByTimePeriod(TimePeriod period)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<RamMetrics>(
                "SELECT * FROM rammetrics WHERE time BETWEEN @fromTime AND @toTime",
                new
                {
                    fromTime = period.FromTime.ToUnixTimeSeconds(),
                    toTime = period.ToTime.ToUnixTimeSeconds()
                }).ToList();
        }

        public IList<RamMetrics> GetByTimePeriodFromAgent(AgentIdTimePeriod period)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.Query<RamMetrics>(
                "SELECT * FROM rammetrics WHERE agentId = @agentId AND time BETWEEN @fromTime AND @toTime",
                new
                {
                    agentId = period.AgentId,
                    fromTime = period.FromTime.ToUnixTimeSeconds(),
                    toTime = period.ToTime.ToUnixTimeSeconds()
                }).ToList();
        }

        public DateTimeOffset GetLastDate(int agentId)
        {
            using var connection = _connection.CreateOpenedConnection();

            return connection.QuerySingle<DateTimeOffset>("Select ifnull(max(Time),0) from rammetrics");
        }
    }
}