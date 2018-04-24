using Microsoft.AspNetCore.Mvc;

namespace CustomerAdmin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}