using Newtonsoft.Json;

namespace Oreo.WebAPI.OpenWeather.Models
{
    public class WeatherResponse // root
    {
        public int Timezone { get; set; }

        [JsonProperty("dt")]
        public int UnixEpochTime { get; set; }

        public Weather[] Weather { get; set; }

        [JsonProperty("main")]
        public Metrics Metrics { get; set; }

        [JsonProperty("name")]
        public string City { get; set; }
    }
}
