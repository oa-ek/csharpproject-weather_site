﻿using System.Text.Json.Serialization;

namespace Weather_site.UI.Models
{
    public class WeatherAPI
    {
        [JsonPropertyName("main")]
        public MainAPI main { get; set; }
        [JsonPropertyName("wind")]
        public WindAPI wind { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("sys")]
        public SysAPI country { get; set; }
        [JsonPropertyName("weather")]
        public List<WeatherIcon> Weather { get; set; }


    }
    public class MainAPI
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("temp_min")]
        public double minM { get; set; }
        [JsonPropertyName("temp_max")]
        public double maxH { get; set; }
        [JsonPropertyName("feels_like")]
        public double feels_like { get; set; }
        [JsonPropertyName("pressure")]
        public int pressure { get; set; }
        [JsonPropertyName("sea_level")]
        public int sea_level { get; set; }
        [JsonPropertyName("grnd_level")]
        public int grnd_level { get; set; }
      
    }
    public class WindAPI
    {
        [JsonPropertyName("speed")]
        public double speed { get; set; }
        [JsonPropertyName("deg")]
        public int deg { get; set; }
        [JsonPropertyName("gust")]
        public double gust { get; set; }
    }

    public class SysAPI
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

    }
    public class WeatherIcon
    {
        [JsonPropertyName("main")]
        public string main { get; set; }
    }

}