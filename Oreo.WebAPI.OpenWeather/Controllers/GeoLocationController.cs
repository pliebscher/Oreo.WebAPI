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
    public class GeoLocationController : ControllerBase
    {
        private readonly ILogger<GeoLocationController> _logger;

        private string _apiKey = "e850980c6457ad9e1f2fc72792dd0eca"; // TODO: Inject

        public GeoLocationController(ILogger<GeoLocationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns the geographic (Lat/Lon) location info for a city or cities.
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/geolocation?city=piedmont&state=ca&country=us
        ///     
        /// </remarks>
        /// <param name="location"></param>
        /// <returns>A list of geo locations matching the City, State and Country search criteria.</returns>
        /// <response code="200">Succesfull request</response>
        /// <response code="400">Missing or invalid request data</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IEnumerable<GeoLocation>> Get([FromQuery] GeoLocationRequest location)
        {
            GeoLocation[] locationResonse;

            try
            {
                RestClient client = new RestClient("http://api.openweathermap.org/geo/1.0/direct");
                RestRequest request = new RestRequest($"?q={location.City},{location.State},{location.Country}&appid={_apiKey}");

                RestResponse response = await client.GetAsync(request);
                locationResonse = JsonConvert.DeserializeObject<GeoLocation[]>(response.Content);
            }
            catch (Exception e) 
            {
                _logger.LogError(e,"Error getting location.");
                throw;
            }

            return locationResonse;
        }        
    }
}
