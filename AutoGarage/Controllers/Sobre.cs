using Microsoft.AspNetCore.Mvc;

namespace AutoGarage.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}