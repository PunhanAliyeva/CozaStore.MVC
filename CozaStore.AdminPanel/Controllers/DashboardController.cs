using Microsoft.AspNetCore.Mvc;

namespace CozaStore.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
