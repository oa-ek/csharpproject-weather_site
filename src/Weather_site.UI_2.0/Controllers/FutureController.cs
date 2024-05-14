using Microsoft.AspNetCore.Mvc;

namespace Weather_site.UI_2._0.Controllers
{
    public class FutureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
