using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Countries;
using Weather_site.Repositories.Weathers;
using Weather_site.Repositories.Winds;

namespace Weather_site.UI_2._0.Controllers
{
    public class WindCrud : Controller
    {
        private readonly IWindRepository _windRepository;

        public WindCrud(IWindRepository windRepository)
        {
            _windRepository = windRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateWind()
        {
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Winds = winds;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWind(Wind wind)
        {
            if (ModelState.IsValid)
            {
                await _windRepository.CreateAsync(wind);
                return RedirectToAction("CreateWind");
            }
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Winds = winds;
            return View(wind);
        }

        public async Task<IActionResult> EditWind(Guid id)
        {
            var wind = await _windRepository.GetAsync(id);
            if (wind == null)
            {
                return NotFound();
            }
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Winds = winds;
            return View(wind);
        }

        [HttpPost]
        public async Task<IActionResult> EditWind(Wind wind)
        {
            if (ModelState.IsValid)
            {
                await _windRepository.UpdateAsync(wind);
                return RedirectToAction("CreateWind");
            }
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Winds = winds;
            return View(wind);
        }

        public async Task<IActionResult> DeleteWind(Guid id)
        {
            var wind = await _windRepository.GetAsync(id);
            if (wind == null)
            {
                return NotFound();
            }
            var winds = await _windRepository.GetAllAsync();
            ViewBag.Winds = new SelectList(winds, "Id", "Id");
            ViewBag.Winds = winds;
            await _windRepository.DeleteAsync(id);
            return RedirectToAction("CreateWind");
        }
    }

}
