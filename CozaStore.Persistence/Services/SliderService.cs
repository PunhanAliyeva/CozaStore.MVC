using CozaStore.MVC.Application.DTOs.SliderDTOs;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Repositories;
using CozaStore.MVC.Infrastructure.Extensions;
using CozaStore.MVC.Persistence.Helpers;

namespace CozaStore.MVC.Persistence.Services
{
    public class SliderService : Service<Slider>, ISliderService
    {
        private readonly IRepository<Slider> _repository;

        public SliderService(IRepository<Slider> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(SliderCreateDTO sliderCreateDTO)
        {
            if (sliderCreateDTO.Photo == null || sliderCreateDTO.Photo.Length == 0)
                throw new ArgumentException("Şəkil boş ola bilməz!");

            if (!sliderCreateDTO.Photo.CheckImage())
                throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

            if (sliderCreateDTO.Photo.CheckImageSize(2000))
                throw new ArgumentException("Şəklin ölçüsü 2MB-dan böyükdür!");

            string fileName = sliderCreateDTO.Photo.SaveFile("uploads", "images");

            Slider slider = new() { Title = sliderCreateDTO.Title, SubTitle = sliderCreateDTO.SubTitle, ImageUrl = fileName };

            await _repository.AddAsync(slider);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(SliderUpdateDTO sliderUpdateDTO)
        {
            var slider = await _repository.GetByIdAsync(sliderUpdateDTO.Id);
            if (slider == null)
                throw new KeyNotFoundException("Slayd tapılmadı");

            slider.Title = sliderUpdateDTO.Title;
            slider.SubTitle = sliderUpdateDTO.SubTitle;
            sliderUpdateDTO.ImageUrl = slider.ImageUrl;

            if (sliderUpdateDTO.Photo != null && sliderUpdateDTO.Photo.Length > 0)
            {
                if (!sliderUpdateDTO.Photo.CheckImage())
                    throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

                if (sliderUpdateDTO.Photo.CheckImageSize(2000))
                    throw new ArgumentException("Şəklin ölçüsü çox böyükdür!");

                string newFileName = sliderUpdateDTO.Photo.SaveFile("uploads", "images");
                FileHelper.DeleteFile("uploads", "images", slider.ImageUrl);
                slider.ImageUrl = newFileName;
            }
            _repository.Update(slider);
            await _repository.SaveAsync();
        }
        //public async Task UpdateAsync(SliderUpdateDTO sliderUpdateDTO)
        //{
        //    var slider = await _repository.GetByIdAsync(sliderUpdateDTO.Id);
        //    if (slider == null)
        //        throw new KeyNotFoundException("Slider tapılmadı.");

        //    // Mətni güncəllə
        //    slider.Title = sliderUpdateDTO.Title?.Trim() ?? slider.Title;
        //    slider.SubTitle = sliderUpdateDTO.SubTitle?.Trim() ?? slider.SubTitle;

        //    // Yeni şəkil göndərilibsə
        //    if (sliderUpdateDTO.Photo is { Length: > 0 })
        //    {
        //        // Format yoxlaması
        //        if (!sliderUpdateDTO.Photo.CheckImage())
        //            throw new ArgumentException("Yalnız şəkil faylı göndərilə bilər!");

        //        // Ölçü yoxlaması (2MB = 2000KB)
        //        if (sliderUpdateDTO.Photo.CheckImageSize(2000))
        //            throw new ArgumentException("Şəkilin ölçüsü 2MB-dan çox ola bilməz!");

        //        // Fayl adı və saxlanılması
        //        string newFileName = sliderUpdateDTO.Photo.SaveFile("uploads", "images");

        //        // Köhnə faylı sil
        //        if (!string.IsNullOrEmpty(slider.ImageUrl))
        //        {
        //            string oldFilePath = Path.Combine("wwwroot", "uploads", "images", slider.ImageUrl);
        //            if (File.Exists(oldFilePath))
        //                File.Delete(oldFilePath);
        //        }

        //        slider.ImageUrl = newFileName;
        //    }

        //    _repository.Update(slider);
        //    await _repository.SaveAsync();
        //}
    }
}
