using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Winds;

namespace Weather_site.UI.Controllers
{
    public class WindController : Controller
    {
        private readonly IWindRepository _windRepository;

        public WindController(IWindRepository windRepository)
        {
            _windRepository = windRepository;
        }

        public async Task<IActionResult> Index()
        {
            var wind = await _windRepository.GetAllAsync();
            return View(wind);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Wind wind)
        {
            if (ModelState.IsValid)
            {
                await _windRepository.CreateAsync(wind);
                return RedirectToAction("Index");
            }
            return View(wind);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var wind = await _windRepository.GetAsync(id);
            return View(wind);
        }

        public async Task<IActionResult> Edit(Wind wind)
        {
            if (ModelState.IsValid)
            {
                await _windRepository.UpdateAsync(wind);
                return RedirectToAction("Index");
            }
            return View(wind);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            await _windRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
