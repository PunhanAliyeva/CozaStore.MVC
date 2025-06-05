using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Application.DTOs.CategoryDTOs;
using CozaStore.MVC.Infrastructure.Extensions;
using CozaStore.MVC.Application.Exceptions;
using System.Drawing;

namespace CozaStore.MVC.Persistence.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository) : base(repository)
        {
            _repository = repository;
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
    }
}

