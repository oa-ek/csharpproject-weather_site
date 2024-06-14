using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace Weather_site.UI_2._0.Controllers
{
    public class FutureController : Controller
    {
        private readonly string apiKey = "8113fcc5a7494b0518bd91ef3acc074f";

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return View();
            }

            string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}&units=metric";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                var content = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(content);

                ViewBag.WeatherData = data;
                ViewBag.City = city;

                if (data != null && data.list != null)
                {
                    var today = DateTime.UtcNow.Date;
                    var tomorrow = today.AddDays(1);

                    // Find today's weather
                    dynamic todayWeather = null;
                    foreach (var item in data.list)
                    {
                        if (DateTime.Parse((string)item.dt_txt).Date == today)
                        {
                            todayWeather = item;
                            break;
                        }
                    }
                    ViewBag.TodayWeather = todayWeather;

                    // Find the weather for the next week
                    var weekWeather = new List<dynamic>();
                    foreach (var item in data.list)
                    {
                        var date = DateTime.Parse((string)item.dt_txt).Date;
                        if (date >= tomorrow && date < tomorrow.AddDays(7))
                        {
                            if (!weekWeather.Any(w => DateTime.Parse((string)w.dt_txt).Date == date))
                            {
                                weekWeather.Add(item);
                            }
                        }
                    }
                    ViewBag.WeekWeather = weekWeather;
                }
            }

            return View();
        }
    }

}


