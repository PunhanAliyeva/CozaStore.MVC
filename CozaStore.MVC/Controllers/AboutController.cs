using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Persistence.Repositories;
using CozaStore.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly IAboutContentService _aboutContentService;
		public AboutController(IAboutService aboutService, IAboutContentService aboutContentService)
		{
			_aboutService = aboutService;
			_aboutContentService = aboutContentService;
		}
		public async Task<IActionResult> Index()
		{
			var about = await _aboutService.GetFirstAsync();
			var aboutContent= await _aboutContentService.GetFirstAsync();
			if (about == null || aboutContent == null) return NotFound();
			AboutVM aboutVM = new() { About = about, AboutContent = aboutContent };
			return View(aboutVM);
		}
	}
}
