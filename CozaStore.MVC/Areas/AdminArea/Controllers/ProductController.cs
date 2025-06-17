using CozaStore.Application.DTOs;
using CozaStore.Application.DTOs.ProductDTOs;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductImageService _productImageService;
        private readonly IProductImageRepository _productImageRepository;
        public ProductController(IProductService productService, ICategoryService categoryService, IProductImageService productImageService, IProductImageRepository productImageRepository)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productImageService = productImageService;
            _productImageRepository = productImageRepository;
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
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            var product = await _productService.GetProductByIdWithIncludesAsync(id);
            if (product == null) return NotFound();

            var productUpdateDTO = new ProductUpdateDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsFeatured = product.IsFeatured,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ProductImages = product.ProductImages.Select(pi => new ProductImageDTO
                {
                    Id = pi.Id,
                    ImageUrl = pi.ImageUrl,
                    IsMain = pi.IsMain
                }).ToList()
            };
            return View(productUpdateDTO);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateDTO productUpdateDTO)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
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
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _productImageService.GetAsync(i => i.Id == id);
            if (image == null) return NotFound();
            await _productImageService.HardDeleteImageAsync(image);
            return RedirectToAction("Update", new { id = image.ProductId });
        }
        public async Task<IActionResult> SetMainPhoto(int id)
        {
            var image = await _productImageService.GetAsync(i => i.Id == id);
            if (image == null) return NotFound();
            image.IsMain = true;
            var existedImage = await _productImageService.GetAsync(i => i.IsMain && i.ProductId == image.ProductId);
            if (existedImage != null)
            {
                existedImage.IsMain = false;
            }
            await _productImageRepository.SaveAsync();
            return RedirectToAction("Update", new { id = image.ProductId });
        }
    }
}
