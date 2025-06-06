using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Application.DTOs.CategoryDTOs;
using CozaStore.MVC.Infrastructure.Extensions;
using CozaStore.MVC.Application.Exceptions;
using CozaStore.MVC.Persistence.Repositories;
using CozaStore.MVC.Persistence.Helpers;

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
			Category category = new()
			{
				Name = categoryCreateDTO.Name,
				Concept = categoryCreateDTO.Concept,
				ParentId = categoryCreateDTO.ParentId,
				ImageUrl = categoryCreateDTO.Photo.SaveFile("uploads", "images")
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

		//public async Task<CategoryGetDTO> DetailAsync(int id)
		//{
		//	var category = await _repository.GetByIdAsync(id);
		//	if (category is null) throw new KeyNotFoundException("Kateqoriya tapılmadı!");
		//	CategoryGetDTO categoryGetDTO = new()
		//	{
		//		Name= category.Name,
		//		Concept = category.Concept,
		//		ParentId = category.ParentId,
		//		ImageUrl = category.ImageUrl,
		//		ParentName = category.Parent?.Name
		//	};
		//	return categoryGetDTO;
		//}

		public async Task<List<CategoryGetDTO>> GetCategoriesWithIncludesAsync()
		{
			var categories = await _categoryRepository.GetCategoriesWithIncludesAsync();
			var dtos = categories.Select(c => new CategoryGetDTO
			{
				Name = c.Name,
				Concept = c.Concept,
				ParentId = c.ParentId,
				ImageUrl = c.ImageUrl,
				ParentName = c.Parent?.Name
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
			return categoriesGetDTO;
		}
	}
}

