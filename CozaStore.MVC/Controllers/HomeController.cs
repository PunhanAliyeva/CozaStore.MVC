using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

		public HomeController(IProductService productService, ICategoryService categoryService, ISliderService sliderService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_sliderService = sliderService;
		}

		public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new();
            var sliders = await _sliderService.GetAllAsync();
            var categories=await _categoryService.GetAllAsync();
            var products=await _productService.GetProductsWithIncludesAsync();
            homeVM.Products = products;
            homeVM.Categories = categories;
            homeVM.Sliders = sliders;
            return View(homeVM);
        }
    }
}
