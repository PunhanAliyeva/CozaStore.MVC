using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Application.DTOs.CategoryDTOs;
using CozaStore.MVC.Infrastructure.Extensions;
using CozaStore.MVC.Application.Exceptions;
using CozaStore.MVC.Persistence.Repositories;
using CozaStore.MVC.Persistence.Helpers;
using CozaStore.MVC.Application.DTOs.SliderDTOs;

namespace CozaStore.MVC.Persistence.Services
{
	public class CategoryService : Service<Category>, ICategoryService
	{
		private readonly IRepository<Category> _repository;
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(IRepository<Category> repository, ICategoryRepository categoryRepository) : base(repository)
		{
			_repository = repository;
			_categoryRepository = categoryRepository;
		}

		public async Task CreateAsync(CategoryCreateDTO categoryCreateDTO)
		{
			if (string.IsNullOrWhiteSpace(categoryCreateDTO.Name))
				throw new ArgumentException("Kateqoriya adı boş ola bilməz!");
			if (await _repository.AnyAsync(c => c.Name.Trim().ToLower() == categoryCreateDTO.Name.ToLower()))
				throw new ValidationException("Name", "Bu adda kateqoriya artıq mövcuddur!");
			if (categoryCreateDTO.Photo == null || categoryCreateDTO.Photo.Length == 0)
				throw new ArgumentException("Şəkil boş ola bilməz!");

			if (!categoryCreateDTO.Photo.CheckImage())
				throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

			if (categoryCreateDTO.Photo.CheckImageSize(2000))
				throw new ArgumentException("Şəklin ölçüsü 2MB-dan böyükdür!");

			Category category = new()
			{
				Name = categoryCreateDTO.Name,
				Concept = categoryCreateDTO.Concept,
				ParentId = categoryCreateDTO.ParentId,
				ImageUrl = categoryCreateDTO.Photo.SaveFile("uploads", "images"),
				CreatedAt = DateTime.UtcNow
			};
			await _repository.AddAsync(category);
			await _repository.SaveAsync();
		}
		public async Task DeleteAsync(int id)
		{
			var category = await _repository.GetByIdAsync(id);
			if (category is null) throw new KeyNotFoundException("Kateqoriya tapılmadı!");
			_repository.Delete(category);
			FileHelper.DeleteFile("uploads", "images", category.ImageUrl);
			await _repository.SaveAsync();
		}

		public async Task<List<CategoryGetDTO>> GetCategoriesWithIncludesAsync()
		{
			var categories = await _categoryRepository.GetCategoriesWithIncludesAsync();
			var dtos = categories.Select(c => new CategoryGetDTO
			{
				Name = c.Name,
				Concept = c.Concept,
				ParentId = c.ParentId,
				ImageUrl = c.ImageUrl,
				ParentName = c.Parent?.Name,
				CreatedAt = c.CreatedAt,
				ModifiedAt = c.UpdatedAt
			}).ToList();
			return dtos;
		}

		public async Task<CategoryGetDTO> GetCategoriesWithIncludesAsync(int id)
		{
			var category = await _categoryRepository.GetCategoriesWithIncludesAsync(id);
			if (category is null) throw new ArgumentException("Bu kateqoriya tapılmadı");
			CategoryGetDTO categoriesGetDTO = new();
			categoriesGetDTO.Name = category.Name;
			categoriesGetDTO.Concept = category.Concept;
			categoriesGetDTO.ParentId = category.ParentId;
			categoriesGetDTO.ImageUrl = category.ImageUrl;
			categoriesGetDTO.ParentName = category.Parent?.Name;
			categoriesGetDTO.CreatedAt = category.CreatedAt;
			categoriesGetDTO.ModifiedAt = category.UpdatedAt;
			return categoriesGetDTO;
		}

		public async Task UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
		{
			var category = await _categoryRepository.GetByIdAsync(categoryUpdateDTO.Id);
			if (category is null) throw new KeyNotFoundException("Kateqoriya tapılmadı!");
			if (await _repository.AnyAsync(c => c.Name.Trim().ToLower() == categoryUpdateDTO.Name.Trim().ToLower() && c.Id != categoryUpdateDTO.Id))
				throw new ValidationException("Name", "Bu kateqoriya artıq mövcuddur!");
			category.Name = categoryUpdateDTO.Name;
			category.Concept = categoryUpdateDTO.Concept;
			category.ParentId = categoryUpdateDTO.ParentId;
			categoryUpdateDTO.ImageUrl = category.ImageUrl;
			if (categoryUpdateDTO.Photo is not null || categoryUpdateDTO.Photo?.Length>0)
			{
				if (!categoryUpdateDTO.Photo.CheckImage())
					throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

				if (categoryUpdateDTO.Photo.CheckImageSize(2000))
					throw new ArgumentException("Şəklin ölçüsü çox böyükdür!");

				string newFileName = categoryUpdateDTO.Photo.SaveFile("uploads", "images");
				FileHelper.DeleteFile("uploads", "images", category.ImageUrl);
				category.ImageUrl = newFileName;
			}
			category.UpdatedAt = DateTime.UtcNow;
			_repository.Update(category);
			await _repository.SaveAsync();
		}
	}
}
