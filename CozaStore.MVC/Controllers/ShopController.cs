using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
	public class ShopController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ShopController(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			ShopVM shopVM = new()
			{
				Categories = await _categoryService.GetAllAsync(),
				Products=await _productService.GetProductsWithIncludesAsync()
			};
			return View(shopVM);
		}
	}
}
