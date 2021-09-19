﻿using System;
using System.Collections.Generic;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        //void Create(T item);

        //IList<T> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime);

        IList<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}