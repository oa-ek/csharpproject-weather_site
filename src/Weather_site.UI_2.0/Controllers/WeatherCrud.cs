using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Countries;
using Weather_site.Repositories.Weathers;
using Weather_site.Repositories.Winds;

namespace Weather_site.UI_2._0.Controllers
{
    public class WeatherCrud : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IWindRepository _windRepository;   

        public WeatherCrud(IWeatherRepository weatherRepository, ICityRepository cityRepository, IWindRepository windRepository)
        {
            _weatherRepository = weatherRepository;
            _cityRepository = cityRepository;
            _windRepository = windRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateWeather()
        {
            var cities = await _cityRepository.GetAllAsync();
            var weathers = await _weatherRepository.GetAllAsync();
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Weathers = new SelectList(weathers, "Id");
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Weathers = weathers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeather(Weather weather)
        {
            if (ModelState.IsValid)
            {
                await _weatherRepository.CreateAsync(weather);
                return RedirectToAction("CreateWeather");
            }

            var cities = await _cityRepository.GetAllAsync();
            var weathers = await _weatherRepository.GetAllAsync();
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Weathers = new SelectList(weathers, "Id");
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Weathers = weathers;
            return View(weather);
        }

        public async Task<IActionResult> EditWeather(Guid id)
        {
            var weather = await _weatherRepository.GetAsync(id);
            if (weather == null)
            {
                return NotFound();
            }
            var cities = await _cityRepository.GetAllAsync();
            var weathers = await _weatherRepository.GetAllAsync();
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Weathers = new SelectList(weathers, "Id");
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Weathers = weathers;
            return View(weather);
        }

        [HttpPost]
        public async Task<IActionResult> EditWeather(Weather weather)
        {
            if (ModelState.IsValid)
            {
                await _weatherRepository.UpdateAsync(weather);
                return RedirectToAction("CreateWeather");
            }
            var cities = await _cityRepository.GetAllAsync();
            var weathers = await _weatherRepository.GetAllAsync();
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Weathers = new SelectList(weathers, "Id");
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Weathers = weathers;
            return View(weather);
        }

        public async Task<IActionResult> DeleteWeather(Guid id)
        {
            var weather = await _weatherRepository.GetAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            await _weatherRepository.DeleteAsync(id);
            return RedirectToAction("CreateWeather");
        }
    }

}

