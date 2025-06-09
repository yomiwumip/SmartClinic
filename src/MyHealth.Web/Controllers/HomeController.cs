using Microsoft.AspNetCore.Mvc;

namespace SmartClinic.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
