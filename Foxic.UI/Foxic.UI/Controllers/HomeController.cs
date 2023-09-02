using Microsoft.AspNetCore.Mvc;

namespace Foxic.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
