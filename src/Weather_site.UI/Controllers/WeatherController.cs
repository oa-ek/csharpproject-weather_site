using Microsoft.AspNetCore.Mvc;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Weathers;

namespace Weather_site.UI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _weatherRepository.GetAllAsync();
            return View(weather);
        }

        public IActionResult Create()
        {
            return View();
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
    }
}
