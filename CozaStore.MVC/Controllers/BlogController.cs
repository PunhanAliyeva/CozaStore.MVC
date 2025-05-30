using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IProductService _productService;

		public BlogController(IBlogService blogService, IProductService productService)
		{
			_blogService = blogService;
			_productService = productService;
		}
		public async Task<IActionResult> Index()
		{
			BlogVM blogVM = new()
			{
				Blogs = await _blogService.GetAllAsync(),
				Products=await _productService.GetAllAsync()
			};
			return View(blogVM);
		}
	}
}
