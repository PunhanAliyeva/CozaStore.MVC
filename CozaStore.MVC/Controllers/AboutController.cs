using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
    public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}
		public async Task<IActionResult> Index()
		{
			var abouts = await _aboutService.GetAllAsync();
			return View(abouts);
		}
    }
}
