using CozaStore.MVC.Application.DTOs.AboutDTOs;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
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
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View(aboutCreateDTO);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            if (about is null) return NotFound();
            return View(about);
        }
        //public async Task<IActionResult> Update(int id,AboutUpdateDTO aboutUpdateDTO)
        //{
        //    if (id != aboutUpdateDTO.Id) return BadRequest();
        //    if(model)
        //}

    }
}
