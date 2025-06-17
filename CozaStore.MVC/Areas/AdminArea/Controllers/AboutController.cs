using CozaStore.Application.DTOs.AboutDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            var abouts=await _aboutService.GetAllAsync();
            return View(abouts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AboutCreateDTO aboutCreateDTO)
        {
            if (!ModelState.IsValid) return View(aboutCreateDTO);
            try
            {
                await _aboutService.CreateAsync(aboutCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(aboutCreateDTO);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
                return View(aboutCreateDTO);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var about = await _aboutService.GetAsync(a=>a.Id==id);
            if (about == null) return NotFound();
            return View(about);
        }
        public async Task<IActionResult> Update(int id)
        {
            var about = await _aboutService.GetAsync(a => a.Id == id);
            if (about == null) return NotFound();
            AboutUpdateDTO aboutUpdateDTO = new() { Title = about.Title, Description = about.Description, ImageUrl = about.ImageUrl };
            return View(aboutUpdateDTO);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, AboutUpdateDTO aboutUpdateDTO)
        {
            if (id != aboutUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(aboutUpdateDTO);
            try
            {
                await _aboutService.UpdateAsync(aboutUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
                return View(aboutUpdateDTO);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(aboutUpdateDTO);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _aboutService.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (KeyNotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
