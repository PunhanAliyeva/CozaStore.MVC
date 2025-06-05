using CozaStore.Domain.Interfaces.IServices;
using CozaStore.MVC.Application.DTOs.ColorDTOs;
using CozaStore.MVC.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            var colors=await _colorService.GetAllAsync();
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ColorCreateDTO colorCreateDTO)
        {
            if (!ModelState.IsValid) return View(colorCreateDTO);
            try
            {
                await _colorService.CreateAsync(colorCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(colorCreateDTO);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            if (color == null) return NotFound();
            ColorUpdateDTO colorUpdateDTO = new() { Name = color.Name };
            return View(colorUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, ColorUpdateDTO colorUpdateDTO)
        {
            if (id != colorUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(colorUpdateDTO);
            try
            {
                await _colorService.UpdateAsync(colorUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(colorUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            if (color is null) return NotFound();
            return View(color);
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _colorService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
