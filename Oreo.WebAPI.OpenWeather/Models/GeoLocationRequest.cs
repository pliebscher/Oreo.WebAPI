using System.ComponentModel.DataAnnotations;

namespace Oreo.WebAPI.OpenWeather.Models
{
    public class GeoLocationRequest
    {
        [Required]
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
    }
}
