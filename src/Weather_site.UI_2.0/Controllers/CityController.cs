using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Countries;

namespace Weather_site.UI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IActionResult> Index()
        {
            var city = await _cityRepository.GetAllAsync();
            return View(city);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.CreateAsync(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            return View(city);
        }

        public async Task<IActionResult> Edit(City city)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.UpdateAsync(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
