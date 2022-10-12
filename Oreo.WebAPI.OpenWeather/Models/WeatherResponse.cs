using Newtonsoft.Json;

namespace Oreo.WebAPI.OpenWeather.Models
{
    public class WeatherResponse
    {
        [JsonProperty("list")]
        public Forecast[] Forecast { get; set; }
        
        public City City { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        
        public Coord Coord { get; set; }
        
        public string Country { get; set; }
        
        public int Population { get; set; }
        
        public int Timezone { get; set; }
        
        public int Sunrise { get; set; }
        
        public int Sunset { get; set; }
    }

    public class Coord
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Forecast
    {
        [JsonProperty("dt")]
        public int UnixEpochTime { get; set; }
        
        public Main Main { get; set; }
        
        public Weather[] Weather { get; set; }
        
        //public Clouds Clouds { get; set; }
        
        public Wind Wind { get; set; }
        
        public int Visibility { get; set; }
        
        [JsonProperty("dt_txt")]
        public string LocalDateTime { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        //public float temp_kf { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }

        public int Deg { get; set; }

        public float Gust { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Summary { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}
