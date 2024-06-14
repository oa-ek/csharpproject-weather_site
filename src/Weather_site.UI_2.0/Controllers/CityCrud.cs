using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Countries;

namespace Weather_site.UI_2._0.Controllers
{
    public class CityCrud : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public CityCrud(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCity()
        {
            var countries = await _countryRepository.GetAllAsync();
            var cities = await _cityRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Cities = cities;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(City city)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.CreateAsync(city);
                return RedirectToAction("CreateCity");
            }

            var countries = await _countryRepository.GetAllAsync();
            var cities = await _cityRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Cities = cities;
            return View(city);
        }

        public async Task<IActionResult> EditCity(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            var countries = await _countryRepository.GetAllAsync();
            var cities = await _cityRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name", city.CountryId);
            ViewBag.Cities = cities;
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> EditCity(City city)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.UpdateAsync(city);
                return RedirectToAction("CreateCity");
            }

            var countries = await _countryRepository.GetAllAsync();
            var cities = await _cityRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name", city.CountryId);
            ViewBag.Cities = cities;
            return View(city);
        }

        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            await _cityRepository.DeleteAsync(id);
            return RedirectToAction("CreateCity");
        }
    }


}
