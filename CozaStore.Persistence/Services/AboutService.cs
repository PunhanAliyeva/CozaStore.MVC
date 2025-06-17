using CozaStore.Application.DTOs.AboutDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Persistence.Helpers;
using CozaStore.Infrastructure.Extensions;

namespace CozaStore.Persistence.Services
{
    public class AboutService : Service<About>, IAboutService
	{
		private readonly IRepository<About> _repository;

		public AboutService(IRepository<About> repository) : base(repository)
		{
			_repository = repository;
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
            if (await _repository.AnyAsync(a => a.Title.Trim().ToLower() == aboutCreateDTO.Title.Trim().ToLower() && a.DeletedAt==null))
                throw new ValidationException("Title", "Bu adda başlıq artıq mövcuddur!");
            About about = new() { Title=aboutCreateDTO.Title,Description=aboutCreateDTO.Description,ImageUrl=fileName,CreatedAt=DateTime.UtcNow};
			await _repository.AddAsync(about);
			await _repository.SaveAsync();
		}

        public async Task DeleteAsync(int id)
        {
            var about=await _repository.GetAsync(a=>a.Id==id);
            if (about == null)
                throw new KeyNotFoundException("Haqqında tapılmadı!");
            _repository.Delete(about);
            FileHelper.DeleteFile("uploads", "images", about.ImageUrl);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(AboutUpdateDTO aboutUpdateDTO)
        {
            var about = await _repository.GetAsync(a=>a.Id==aboutUpdateDTO.Id);
            if (about == null)
                throw new KeyNotFoundException("Haqqında tapılmadı!");
            if (await _repository.AnyAsync(a => a.Title.Trim().ToLower() == aboutUpdateDTO.Title.Trim().ToLower() && a.DeletedAt==null && a.Id!=aboutUpdateDTO.Id))
                throw new ValidationException("Title", "Bu başlıq artıq mövcuddur!");
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
