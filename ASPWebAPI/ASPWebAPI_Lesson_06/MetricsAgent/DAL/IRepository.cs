using System;
using System.Collections.Generic;

namespace MetricsAgent.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime);

        void Create(T item);
    }
}