using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Weathers;
using Weather_site.Repositories.Countries;
using Weather_site.Repositories.Winds;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Weather_site.UI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Weather_site.UI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IWindRepository _windRepository;

        public WeatherController(IWeatherRepository weatherRepository, ICountryRepository countryRepository, ICityRepository cityRepository, IWindRepository windRepository)
        {
            _weatherRepository = weatherRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _windRepository = windRepository;
        }

        public async Task<IActionResult> GetFromAPI(Guid Id) 
        {
            var weather = await _weatherRepository.GetAsync(Id);
            return View(weather);
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _weatherRepository.GetAllAsync();
            return View(weather);
        }


        public async Task<IActionResult> IndexAPI()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var cities = await _cityRepository.GetAllAsync();
            var winds = await _windRepository.GetAllAsync();

            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Winds = new SelectList(winds, "Id", "Speed");

            return View(new Weather());
        }
        [HttpPost]

        public async Task<IActionResult> Create(Weather weather)
        {

            if (ModelState.IsValid)
            {
                await _weatherRepository.CreateAsync(weather);
                return RedirectToAction("Index");
            }
            return View(weather);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var weather = await _weatherRepository.GetAsync(id);
            return View(weather);
        }

        public async Task<IActionResult> Edit(Weather weather)
        {
            if (ModelState.IsValid)
            {
                await _weatherRepository.UpdateAsync(weather);
                return RedirectToAction("Index");
            }
            return View(weather);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            await _weatherRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> WeatherDetail(string City)
        {
            string appId = "8113fcc5a7494b0518bd91ef3acc074f";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={City}&units=metric&cnt=1&APPID=8113fcc5a7494b0518bd91ef3acc074f";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var weatherInfo = JsonSerializer.Deserialize<WeatherAPI>(json);

                    Guid WindId = Guid.NewGuid();
                    var wind = new Wind
                    {
                        Id = WindId,
                        Speed = weatherInfo.wind.speed,
                        Humidity = weatherInfo.wind.deg

                    };
                    await _windRepository.CreateAsync(wind);
                    var wind1 = await _windRepository.GetAsync(wind.Id);
                    var country = await _countryRepository.GetByName(weatherInfo.country.Country);
                    Guid CountryId = Guid.NewGuid();
                    if (country == null)
                    {
                        Country country1 = new Country
                        {
                            Id = CountryId,
                            Name = weatherInfo.country.Country
                        };
                        await _countryRepository.CreateAsync(country1);
                        country = country1;

                    }


                    var city = await _cityRepository.GetByName(weatherInfo.Name);

                    if (country != null)
                    {
                        City city1 = new City
                        {
                            Id = CountryId,
                            Name = weatherInfo.Name,
                            Country = country
                        };

                        await _cityRepository.CreateAsync(city1);
                        city = city1;
                    }



                    city = await _cityRepository.GetByName(weatherInfo.Name);
                    Guid WeatherId = Guid.NewGuid();
                    var weather = new Weather
                    {
                        Id = WeatherId,
                        City = city,
                        MinT = weatherInfo.main.minM,
                        MaxT = weatherInfo.main.maxH,
                        FeelsLikeT = weatherInfo.main.feels_like,
                        Wind = wind,
                        Date = DateTime.Now,
                        Icon = weatherInfo.icon 
                    };
                    await _weatherRepository.CreateAsync(weather);
                    return RedirectToAction("GetFromAPI", "Weather", new { Id = WeatherId });
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
