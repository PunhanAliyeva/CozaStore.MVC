using CozaStore.Application.DTOs.SizeDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        public async Task<IActionResult> Index()
        {
            var sizes=await _sizeService.GetAllAsync();
            return View(sizes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SizeCreateDTO sizeCreateDTO)
        {
            if (!ModelState.IsValid) return View(sizeCreateDTO);
            try
            {
                await _sizeService.CreateAsync(sizeCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Name",ex.Message);
                return View(sizeCreateDTO);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var size = await _sizeService.GetByIdAsync(id);
            if (size is null) return NotFound();
            return View(size);
        }
        public async Task<IActionResult> Update(int id)
        {
            var size = await _sizeService.GetByIdAsync(id);
            if (size == null) return NotFound();
            SizeUpdateDTO sizeUpdateDTO = new() { Name = size.Name };
            return View(sizeUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, SizeUpdateDTO sizeUpdateDTO)
        {
            if (id != sizeUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(sizeUpdateDTO);
            try
            {
                await _sizeService.UpdateAsync(sizeUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(sizeUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sizeService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new {success= false ,message=ex.Message});
            }
        }
    }
}
