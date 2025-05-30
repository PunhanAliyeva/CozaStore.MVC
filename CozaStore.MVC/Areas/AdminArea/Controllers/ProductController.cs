using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
	[Area("AdminArea")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var products=await _productService.GetAllAsync();
			return View(products);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Product product)
		{
			if(!ModelState.IsValid) return View(product);
			await _productService.AddAsync(product);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Detail(int id)
		{
			var product=await _productService.GetByIdAsync(id);
			if(product is null) return View(product);
			return View(product);
		}
		public async Task<IActionResult> Update(int id)
		{
			var product = await _productService.GetByIdAsync(id);
			if (product is null) return View(product);
			return View(product);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public  async Task<IActionResult> Update(int id,Product product)
		{
            if(id!=product.Id) return BadRequest();
			if (!ModelState.IsValid) return View(product);
			await _productService.UpdateAsync(product);
			return RedirectToAction(nameof(Index));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var product=await _productService.GetByIdAsync(id);
			if(product is null) return NotFound();
			await _productService.DeleteAsync(product);
			return RedirectToAction(nameof(Index));
		}
	}
}
