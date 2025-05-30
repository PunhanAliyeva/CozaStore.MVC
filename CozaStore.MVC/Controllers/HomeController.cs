using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
