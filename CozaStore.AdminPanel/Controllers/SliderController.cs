using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.AdminPanel.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View(slider);
            await _sliderService.AddAsync(slider);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null) return NotFound();
            await _sliderService.DeleteAsync(slider);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {
            if (id != slider.Id) return BadRequest();
            if (!ModelState.IsValid) return View(slider);
            await _sliderService.UpdateAsync(slider);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
    }
}
