using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.AdminPanel.Controllers
{
    [Area("AdminArea")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
