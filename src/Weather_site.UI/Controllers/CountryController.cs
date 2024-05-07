using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Countries;

namespace Weather_site.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var country = await _countryRepository.GetAllAsync();
            return View(country);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Country country) 
        {
            if (ModelState.IsValid) 
            {
                await _countryRepository.CreateAsync(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var country = await _countryRepository.GetAsync(id);
            return View(country);
        }

        public async Task<IActionResult> Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                await _countryRepository.UpdateAsync(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

