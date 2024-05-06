using Microsoft.AspNetCore.Mvc;
using Weather_site.Repositories.WeatherRepository;

namespace Weather_site.UI.Controllers
{
    public class WeathersController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
