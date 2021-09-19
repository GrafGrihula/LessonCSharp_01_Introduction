using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset Time { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(int value, DateTime dateTime)
        {
            Value = value;
            Time = dateTime;
        }
    }
}
