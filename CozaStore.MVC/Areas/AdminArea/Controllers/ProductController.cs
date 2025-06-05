using CozaStore.MVC.Application.DTOs.ProductDTOs;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
		{
			var products=await _productService.GetProductsWithIncludesAsync();
			return View(products);
		}
		public async Task<IActionResult> Create()
		{
			ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
		{
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            if (!ModelState.IsValid) return View(productCreateDTO);
            try
            {
                await _productService.CreateAsync(productCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photos", ex.Message);
                return View(productCreateDTO);
            }
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
