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
        private readonly ILogger<GeoLocationController> _log;

        private string _apiKey = "e850980c6457ad9e1f2fc72792dd0eca"; // TODO: Inject

        public GeoLocationController(ILogger<GeoLocationController> logger)
        {
            _log = logger;
        }

        /// <summary>
        /// /api/geolocation?city=piedmont&state=ca&country=us
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpGet]        
        public async Task<IEnumerable<GeoLocation>> Get([FromQuery] GeoLocationRequest location)
        {
            GeoLocation[] locationResonse;

            try
            {
                RestClient client = new RestClient("http://api.openweathermap.org/geo/1.0");
                RestRequest request = new RestRequest($"direct?q={location.City},{location.State},{location.Country}&appid={_apiKey}");

                RestResponse response = await client.GetAsync(request);
                locationResonse = JsonConvert.DeserializeObject<GeoLocation[]>(response.Content);
            }
            catch (Exception e) 
            {
                _log.LogError(e,"Error getting location.");
                throw;
            }

            return locationResonse;
        }        
    }
}
