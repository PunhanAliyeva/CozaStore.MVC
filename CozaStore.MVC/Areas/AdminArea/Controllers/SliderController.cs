using CozaStore.MVC.Application.DTOs.SliderDTOs;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using CozaStore.MVC.Infrastructure.Extensions;

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
			var photo = sliderCreateDTO.Photo;
			if (photo is null || photo.Length == 0)
			{
				ModelState.AddModelError("Photo", "Şəkil boş ola bilməz!");
				return View();
			}
			if (!photo.CheckImage())
			{
				ModelState.AddModelError("Photo", "Yalnız şəkil göndərilə bilər!");
				return View();
			}
			if (photo.CheckImageSize(2000))
			{
				ModelState.AddModelError("Photo", "Şəklin ölçüsü çox böyükdür!");
				return View();
			}

			Slider slider = new(){Title = sliderCreateDTO.Title,SubTitle = sliderCreateDTO.SubTitle,ImageUrl = photo.SaveFile("uploads", "images")};
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

		public async Task<IActionResult> Update(int id)
		{
			var slider = await _sliderService.GetByIdAsync(id);
			if (slider == null) return NotFound();
			return View(slider);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, Slider slider)
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
