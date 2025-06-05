using CozaStore.MVC.Application.DTOs.SizeDTOs;
using CozaStore.MVC.Domain.Interfaces.IServices;
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
    }
}
