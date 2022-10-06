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

        public GeoLocationController(ILogger<GeoLocationController> logger)
        {
            _log = logger;
        }

        /// <summary>
        /// GET: api/GeoLocation
        /// </summary>
        /// <param name="Location"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GeoLocation[]> Get(string Location)
        {

            // TODO: Add city, state, country to params and update request query...

            RestClient client = new RestClient("http://api.openweathermap.org/geo/1.0");
            RestRequest request = new RestRequest("direct?q=piedmont,ca,us&limit=1&appid=e850980c6457ad9e1f2fc72792dd0eca");
            RestResponse response = await client.GetAsync(request);

            GeoLocation[] locationResonse = JsonConvert.DeserializeObject<GeoLocation[]>(response.Content);

            return locationResonse;
        }        
    }
}
