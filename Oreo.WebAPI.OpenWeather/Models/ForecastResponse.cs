using Newtonsoft.Json;

namespace Oreo.WebAPI.OpenWeather.Models
{
    public class ForecastResponse // root
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

    public class Forecast // list
    {
        [JsonProperty("dt")]
        public int UnixEpochTime { get; set; }

        [JsonProperty("main")]
        public Metrics Metrics { get; set; }
        
        public Weather[] Weather { get; set; }
        
        //public Clouds Clouds { get; set; }
        
        public Wind Wind { get; set; }
        
        public int Visibility { get; set; }
        
        [JsonProperty("dt_txt")]
        public string LocalDateTime { get; set; }
    }

    public class Metrics
    {
        public float Temp { get; set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public float TempMin { get; set; }

        [JsonProperty("temp_max")]
        public float TempMax { get; set; }
        
        public int Pressure { get; set; }
        
        //public int sea_level { get; set; }
        
        //public int grnd_level { get; set; }
        
        public int Humidity { get; set; }
        
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

    /// <summary>
    /// https://openweathermap.org/weather-conditions
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// See https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2 for a full list of codes
        /// </summary>
        [JsonProperty("id")]
        public int Code { get; set; }

        [JsonProperty("main")]
        public string Summary { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// For code 500 - light rain icon = "10d". See https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2 for a full list of codes
        /// URL is http://openweathermap.org/img/wn/10d@2x.png
        /// </summary>
        public string Icon { get; set; }
    }
}
