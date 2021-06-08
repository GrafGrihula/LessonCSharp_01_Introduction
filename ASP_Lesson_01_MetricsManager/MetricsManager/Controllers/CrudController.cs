using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route( "api/crud" )]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder _holder;
        public CrudController(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost( "create" )]
        public IActionResult Create([FromQuery] DateTime inputTime, [FromQuery] int inputTemper)
        {
            var item = new WeatherForecast() { Time = inputTime, TemperatureC = inputTemper };
            _holder.Weathers.Add( item );
            return Ok( item );
        }

        [HttpGet( "read" )]
        public IActionResult Read([FromQuery] DateTime startTime, DateTime finishTime)
        {
            var item = _holder.GetTemper( startTime, finishTime );

            return Ok( item );
        }

        [HttpPut( "update" )]
        public IActionResult Update([FromQuery] DateTime fromTime, [FromQuery] int temper)
        {
            _holder.UpdateTemper( fromTime, temper );
            return Ok();
        }

        [HttpDelete( "delete" )]
        public IActionResult Delete([FromQuery] DateTime startTime, DateTime finishTime)
        {
            _holder.DeleteTemper( startTime, finishTime );
            return Ok();
        }
    }
}