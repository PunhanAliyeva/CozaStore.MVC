using CozaStore.MVC.Application.DTOs.SliderDTOs;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using CozaStore.MVC.Infrastructure.Extensions;
using Humanizer;

namespace CozaStore.MVC.AdminPanel.Controllers
{
    [Area("AdminArea")]
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
        public async Task<IActionResult> Create(SliderCreateDTO sliderCreateDTO)
        {
            if (!ModelState.IsValid) return View(sliderCreateDTO);
            try
            {
                await _sliderService.CreateAsync(sliderCreateDTO);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(sliderCreateDTO);
            }
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

        public async Task<IActionResult> Update(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null) return NotFound();
            SliderUpdateDTO sliderUpdateDTO = new() { Title = slider.Title, SubTitle = slider.SubTitle, ImageUrl = slider.ImageUrl };
            return View(sliderUpdateDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SliderUpdateDTO sliderUpdateDTO)
        {
            if (id != sliderUpdateDTO.Id) return BadRequest();
            if (!ModelState.IsValid) return View(sliderUpdateDTO);
            try
            {
                await _sliderService.UpdateAsync(sliderUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return View(sliderUpdateDTO);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
    }
}
