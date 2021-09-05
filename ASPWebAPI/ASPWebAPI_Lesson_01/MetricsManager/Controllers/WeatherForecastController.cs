using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
        [Route("[controller]")]
        [ApiController]
        public class WeatherForecastController : ControllerBase
        {
                private readonly ValuesHolder _holder;

                public WeatherForecastController(ValuesHolder holder)
                {
                        _holder = holder;
                }

                [HttpPost]
                public IActionResult Create([FromQuery] DateTime newDate, [FromQuery] int newTemper)
                {
                        var item = new WeatherForecast() { Date = newDate, TemperatureC = newTemper };
                        _holder.Weathers.Add(item);
                        return Ok();
                }

                [HttpGet]
                public IActionResult Read([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
                {
                        var item = _holder.GetWeathers(fromDate, toDate);
                        return Ok(item);
                }

                [HttpPut]
                public IActionResult Update([FromQuery] DateTime searchDate, [FromQuery] int updateTemper)
                {
                        _holder.UpdateWeather(searchDate, updateTemper);
                        return Ok();
                }

                [HttpDelete]
                public IActionResult Delete([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
                {
                        _holder.DeleteWeather(fromDate, toDate);
                        return Ok();
                }
        }
}
