using CozaStore.MVC.Application.DTOs.BlogCategoryDTOs;
using CozaStore.MVC.Application.DTOs.TagDTOs;
using CozaStore.MVC.Application.Exceptions;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using Microsoft.Identity.Client;

namespace CozaStore.MVC.Persistence.Services
{
	public class BlogCategoryService : Service<BlogCategory>, IBlogCategoryService
	{
        private readonly IRepository<BlogCategory> _repository;

        public BlogCategoryService(IRepository<BlogCategory> repository) : base(repository)
		{
            _repository = repository;
        }

        public async Task CreateAsync(BlogCategoryCreateDTO blogCategoryCreateDTO)
        {
            if (string.IsNullOrWhiteSpace(blogCategoryCreateDTO.Name))
                throw new ArgumentException("Teq adı boş ola bilməz!");
            if (await _repository.AnyAsync(bc => bc.Name.Trim().ToLower() == blogCategoryCreateDTO.Name.Trim().ToLower()))
                throw new ValidationException("Name","Bu adda bloq-kateqoriya artıq mövcuddur!");
            BlogCategory blogCategory = new() { Name = blogCategoryCreateDTO.Name, CreatedAt = DateTime.UtcNow };
            await _repository.AddAsync(blogCategory);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blogCategory = await _repository.GetByIdAsync(id);
            if (blogCategory is null) throw new KeyNotFoundException("Bloq-Kateqoriya tapılmadı!");
            blogCategory.DeletedAt=DateTime.UtcNow;
            _repository.Update(blogCategory);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(BlogCategoryUpdateDTO blogCategoryUpdateDTO)
        {
            var blogCategory = await _repository.GetByIdAsync(blogCategoryUpdateDTO.Id);
            if (blogCategory is null) throw new KeyNotFoundException("Bloq-Kateqoriya tapılmadı!");
            if (await _repository.AnyAsync(bc => bc.Name.Trim().ToLower() == blogCategoryUpdateDTO.Name.Trim().ToLower() && bc.Id != blogCategoryUpdateDTO.Id))
                throw new ValidationException("Name", "Bu bloq-kateqoriya artıq mövcuddur!");
            blogCategory.Name = blogCategoryUpdateDTO.Name;
            blogCategory.UpdatedAt= DateTime.UtcNow;
            _repository.Update(blogCategory);
            await _repository.SaveAsync();  
        }
    }
}
