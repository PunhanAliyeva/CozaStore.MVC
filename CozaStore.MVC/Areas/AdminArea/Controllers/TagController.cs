using CozaStore.Application.DTOs.TagDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetAllAsync();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(TagCreateDTO tagCreateDTO)
        {
            if (!ModelState.IsValid) return View(tagCreateDTO);
            try
            {
                await _tagService.CreateAsync(tagCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(tagCreateDTO);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag is null) return NotFound();
            return View(tag);
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tagService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null) return NotFound();
            TagUpdateDTO tagUpdateDTO = new() { Name=tag.Name};
            return View(tagUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, TagUpdateDTO tagUpdateDTO)
        {
            if (id != tagUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(tagUpdateDTO);
            try
            {
                await _tagService.UpdateAsync(tagUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(tagUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
