using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;
using Newtonsoft.Json;

using Oreo.WebAPI.OpenWeather.Models;

namespace Oreo.WebAPI.OpenWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        private string _apiKey = "e850980c6457ad9e1f2fc72792dd0eca"; // TODO: Inject

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        // http://api.openweathermap.org/data/2.5/forecast?lat=37.82&lon=-122.23&units=imperial&cnt=1&appid=e850980c6457ad9e1f2fc72792dd0eca

        /// <summary>
        /// Returns the weather for a given geographical location.
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<WeatherResponse> Get([FromQuery] WeatherRequest weatherRequest)
        {
            WeatherResponse weatherResponse = null;

            try
            {
                RestClient client = new RestClient("http://api.openweathermap.org/data/2.5/forecast");
                RestRequest request = new RestRequest($"?lat={weatherRequest.Lat}&lon={weatherRequest.Lon}&units=imperial&cnt=1&appid={_apiKey}");

                RestResponse response = await client.GetAsync(request);
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response.Content);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting weather.");
                throw;
            }

            return weatherResponse;
        }
    }
}
