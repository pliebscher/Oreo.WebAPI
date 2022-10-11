using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oreo.WebAPI.OpenWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // api.openweathermap.org/data/2.5/forecast?lat=37.8243715&lon=-122.231635&units=imperial&cnt=1&appid=e850980c6457ad9e1f2fc72792dd0eca

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
