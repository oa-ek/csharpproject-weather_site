using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Weather_site.Core.Entities;

namespace Weather_site.UI.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string WeatherDetail(string City)
        {
            string appId = "8113fcc5a7494b0518bd91ef3acc074f";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={City}&units=metric&cnt=1&APPID=8113fcc5a7494b0518bd91ef3acc074f";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var weatherInfo = JsonSerializer.Deserialize<RootObject>(json);

                    var rslt = new ResultViewModel
                    {
                        Country = weatherInfo.sys.country,
                        City = weatherInfo.name,
                        Lat = Convert.ToString(weatherInfo.coord.lat),
                        Lon = Convert.ToString(weatherInfo.coord.lon),
                        Description = weatherInfo.weather[0].description,
                        Humidity = Convert.ToString(weatherInfo.main.humidity),
                        Temp = Convert.ToString(weatherInfo.main.temp),
                        TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like),
                        TempMax = Convert.ToDouble(weatherInfo.main.temp_max),
                        TempMin = Convert.ToDouble(weatherInfo.main.temp_min),
                        WeatherIcon = weatherInfo.weather[0].icon
                    };

                    var jsonstring = JsonSerializer.Serialize(rslt);
                    return jsonstring;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
