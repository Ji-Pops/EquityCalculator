using Microsoft.AspNetCore.Mvc;

namespace EquityCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("CalculateEquityView", "EquityCalculator");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}