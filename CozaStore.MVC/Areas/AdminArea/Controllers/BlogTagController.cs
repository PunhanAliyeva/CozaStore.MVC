using CozaStore.MVC.Application.DTOs.BlogTagDTOs;
using CozaStore.MVC.Application.Exceptions;
using CozaStore.MVC.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
	public class BlogTagController : Controller
	{
		private readonly IBlogTagService _blogTagService;

		public BlogTagController(IBlogTagService blogTagService)
		{
			_blogTagService = blogTagService;
		}

		public async Task<IActionResult> Index()
		{
			var blogTags=await _blogTagService.GetAllAsync();
			return View(blogTags);
		}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(BlogTagCreateDTO blogTagCreateDTO)
        {
            if (!ModelState.IsValid) return View(blogTagCreateDTO);
            try
            {
                await _blogTagService.CreateAsync(blogTagCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(blogTagCreateDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(blogTagCreateDTO);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var blogTag = await _blogTagService.GetByIdAsync(id);
            if (blogTag is null) return NotFound();
            return View(blogTag);
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _blogTagService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var blogTag = await _blogTagService.GetByIdAsync(id);
            if (blogTag == null) return NotFound();
            BlogTagUpdateDTO blogTagUpdateDTO = new() { Name = blogTag.Name };
            return View(blogTagUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, BlogTagUpdateDTO blogTagUpdateDTO)
        {
            if (id != blogTagUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(blogTagUpdateDTO);
            try
            {
                await _blogTagService.UpdateAsync(blogTagUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(blogTagUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
