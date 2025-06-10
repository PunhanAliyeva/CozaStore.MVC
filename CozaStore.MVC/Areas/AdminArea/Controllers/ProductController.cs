using CozaStore.Application.DTOs.ProductDTOs;
using CozaStore.Application.DTOs.SliderDTOs;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Persistence.Services;
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
            var products = await _productService.GetProductsWithIncludesAsync();
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
            try
            {
                var product = await _productService.GetProductByIdWithIncludesAsync(id);
                return View(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            ProductUpdateDTO productUpdateDTO = new() { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price, CategoryId = product.CategoryId };
            return View(productUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateDTO productUpdateDTO)
        {
            if (id != productUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(productUpdateDTO);
            try
            {
                await _productService.UpdateAsync(productUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
                return View(productUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
