using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

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
        private readonly string _apiKey = "";

        public WeatherController(IConfiguration config, ILogger<WeatherController> logger)
        {
            // Add your OpenWeather API key to your local secrets.json file...
            _apiKey = config["OpenWeather:ApiKey"];
            _logger = logger;
        }

        /// <summary>
        /// Returns the weather for a given geographical location.
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns>WeatherResponse</returns>
        [HttpGet("/api/Weather")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<WeatherResponse> Current([FromQuery] WeatherRequest weatherRequest)
        {
            WeatherResponse weatherResponse;

            try
            {
                RestClient client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
                RestRequest request = new RestRequest($"?lat={weatherRequest.Lat}&lon={weatherRequest.Lon}&units=imperial&appid={_apiKey}");

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

        // http://api.openweathermap.org/data/2.5/forecast?lat=37.82&lon=-122.23&units=imperial&cnt=1&appid=e850980c6457ad9e1f2fc72792dd0eca

        /// <summary>
        /// Returns the forecast for a given geographical location.
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns>ForecastResponse</returns>
        [HttpGet("/api/Forecast")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ForecastResponse> Forecast([FromQuery] WeatherRequest weatherRequest)
        {
            ForecastResponse forecastResponse;

            try
            {
                RestClient client = new RestClient("http://api.openweathermap.org/data/2.5/forecast");
                RestRequest request = new RestRequest($"?lat={weatherRequest.Lat}&lon={weatherRequest.Lon}&units=imperial&cnt=5&appid={_apiKey}");

                RestResponse response = await client.GetAsync(request);
                forecastResponse = JsonConvert.DeserializeObject<ForecastResponse>(response.Content);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting forecast.");
                throw;
            }

            return forecastResponse;
        }
    }
}
