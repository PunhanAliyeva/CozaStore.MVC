using CozaStore.Application.DTOs.BlogCategoryDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoryController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var blogCategories = await _blogCategoryService.GetAllAsync();
            return View(blogCategories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(BlogCategoryCreateDTO blogCategoryCreateDTO)
        {
            if (!ModelState.IsValid) return View(blogCategoryCreateDTO);
            try
            {
                await _blogCategoryService.CreateAsync(blogCategoryCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(blogCategoryCreateDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(blogCategoryCreateDTO);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var blogCategory = await _blogCategoryService.GetByIdAsync(id);
            if (blogCategory == null) return NotFound();
            BlogCategoryUpdateDTO blogCategoryUpdateDTO = new() { Name = blogCategory.Name };
            return View(blogCategoryUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, BlogCategoryUpdateDTO blogCategoryUpdateDTO)
        {
            if (id != blogCategoryUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(blogCategoryUpdateDTO);
            try
            {
                await _blogCategoryService.UpdateAsync(blogCategoryUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(blogCategoryUpdateDTO);
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
                await _blogCategoryService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var blogCategory = await _blogCategoryService.GetByIdAsync(id);
            if (blogCategory is null) return NotFound();
            return View(blogCategory);
        }
}
}
