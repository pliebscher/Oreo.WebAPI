using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Oreo.WebAPI.OpenWeather.Models
{
    public class WeatherRequest
    {
        [Required]
        public float Lat { get; set; }

        [Required]
        public float Lon { get; set; }
    }
}
