using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Countries;

namespace Weather_site.UI_2._0.Controllers
{
    public class CountryCrud : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryCrud(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCountry()
        {
            var countries = await _countryRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                await _countryRepository.CreateAsync(country);
                return RedirectToAction("CreateCountry");
            }
            var countries = await _countryRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = countries;
            return View(country);
        }

        public async Task<IActionResult> EditCountry(Guid id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            var countries = await _countryRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = countries;
            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> EditCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                await _countryRepository.UpdateAsync(country);
                return RedirectToAction("CreateCountry");
            }
            var countries = await _countryRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = countries;
            return View(country);
        }

        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            var countries = await _countryRepository.GetAllAsync();
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = countries;
            await _countryRepository.DeleteAsync(id);
            return RedirectToAction("CreateCountry");
        }
    }


}
