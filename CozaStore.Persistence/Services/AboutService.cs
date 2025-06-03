using CozaStore.MVC.Application.DTOs.AboutDTOs;
using CozaStore.MVC.Application.DTOs.SliderDTOs;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Infrastructure.Extensions;
using CozaStore.MVC.Persistence.Helpers;
using CozaStore.MVC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Services
{
	public class AboutService : Service<About>, IAboutService
	{
		private readonly IAboutRepository _repository;

		public AboutService(IAboutRepository repository) : base(repository)
		{
			_repository = repository;
		}
		public async Task<About> GetFirstAsync()
		{
			return await _repository.GetFirstAsync();
		}
		public async Task CreateAsync(AboutCreateDTO aboutCreateDTO)
		{
			if (aboutCreateDTO.Photo is null || aboutCreateDTO.Photo.Length == 0)
				throw new ArgumentException("Şəkil boş ola bilməz!");
			if (!aboutCreateDTO.Photo.CheckImage())
				throw new ArgumentException("Yalniz şəkil göndərilə bilər!");
			if (aboutCreateDTO.Photo.CheckImageSize(2000))
				throw new ArgumentException("Şəklin ölçüsü 2MB-dan çox olmamalıdır!");
            string fileName = aboutCreateDTO.Photo.SaveFile("uploads", "images");
            About about = new() { Title=aboutCreateDTO.Title,Description=aboutCreateDTO.Description,ImageUrl=fileName,UpdatedAt=DateTime.UtcNow};
			await _repository.AddAsync(about);
			await _repository.SaveAsync();
		}

        public async Task UpdateAsync(AboutUpdateDTO aboutUpdateDTO)
        {
            var about = await _repository.GetByIdAsync(aboutUpdateDTO.Id);
            if (about == null)
                throw new KeyNotFoundException("Slayd tapılmadı");

            about.Title = aboutUpdateDTO.Title;
            about.Description = aboutUpdateDTO.Description;
            aboutUpdateDTO.ImageUrl = about.ImageUrl;

            if (aboutUpdateDTO.Photo != null && aboutUpdateDTO.Photo.Length > 0)
            {
                if (!aboutUpdateDTO.Photo.CheckImage())
                    throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

                if (aboutUpdateDTO.Photo.CheckImageSize(2000))
                    throw new ArgumentException("Şəklin ölçüsü çox böyükdür!");

                string newFileName = aboutUpdateDTO.Photo.SaveFile("uploads", "images");
                FileHelper.DeleteFile("uploads", "images", about.ImageUrl);
                about.ImageUrl = newFileName;
            }
            about.UpdatedAt = DateTime.UtcNow;
            _repository.Update(about);
            await _repository.SaveAsync();
        }
    }
}
