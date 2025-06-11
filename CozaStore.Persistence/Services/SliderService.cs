using CozaStore.Application.DTOs.SliderDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Persistence.Helpers;
using CozaStore.Infrastructure.Extensions;

namespace CozaStore.Persistence.Services
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
            if (await _repository.AnyAsync(s => s.Title.Trim().ToLower() == sliderCreateDTO.Title.Trim().ToLower() && s.DeletedAt == null))
                throw new ValidationException("Title", "Bu başlıqda slayd artıq mövcuddur!");

            if (sliderCreateDTO.Photo == null || sliderCreateDTO.Photo.Length == 0)
                throw new ArgumentException("Şəkil boş ola bilməz!");

            if (!sliderCreateDTO.Photo.CheckImage())
                throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

            if (sliderCreateDTO.Photo.CheckImageSize(2000))
                throw new ArgumentException("Şəklin ölçüsü 2MB-dan böyükdür!");

            string fileName = sliderCreateDTO.Photo.SaveFile("uploads", "images");

            Slider slider = new() { Title = sliderCreateDTO.Title, SubTitle = sliderCreateDTO.SubTitle, ImageUrl = fileName,CreatedAt=DateTime.UtcNow };

            await _repository.AddAsync(slider);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(SliderUpdateDTO sliderUpdateDTO)
        {
            var slider = await _repository.GetByIdAsync(sliderUpdateDTO.Id);
            if (slider == null) throw new KeyNotFoundException("Slayd tapılmadı");

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
            slider.UpdatedAt = DateTime.UtcNow;
            _repository.Update(slider);
            await _repository.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var slider = await _repository.GetByIdAsync(id);
            if (slider == null) throw new KeyNotFoundException("Slayd tapılmadı");
            _repository.Delete(slider);
            FileHelper.DeleteFile("uploads", "images", slider.ImageUrl);
            await _repository.SaveAsync();
        }
    }
}
