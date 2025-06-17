using CozaStore.Application.DTOs.CategoryDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CozaStore.MVC.AdminPanel.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            if (!ModelState.IsValid) return View(categoryCreateDTO);
            try
            {
                await _categoryService.CreateAsync(categoryCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
                return View(categoryCreateDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(categoryCreateDTO);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var categoryDTO = await _categoryService.GetCategoriesWithIncludesAsync(id);
                return View(categoryDTO);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            var category = await _categoryService.GetAsync(c=>c.Id==id);
            if (category == null) return NotFound();
            CategoryUpdateDTO categoryUpdateDTO = new()
            {
                Name = category.Name,
                Concept = category.Concept,
                ImageUrl = category.ImageUrl,
                ParentId = category.ParentId
            };
            return View(categoryUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            if (id != categoryUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(categoryUpdateDTO);
            try
            {
                await _categoryService.UpdateAsync(categoryUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
                return View(categoryUpdateDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(categoryUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
