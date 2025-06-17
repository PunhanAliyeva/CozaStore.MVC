using CozaStore.Application.DTOs.BlogCategoryDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;


namespace CozaStore.Persistence.Services
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
            if (await _repository.AnyAsync(bc => bc.Name.Trim().ToLower() == blogCategoryCreateDTO.Name.Trim().ToLower() && bc.DeletedAt==null))
                throw new ValidationException("Name","Bu adda bloq-kateqoriya artıq mövcuddur!");
            BlogCategory blogCategory = new() { Name = blogCategoryCreateDTO.Name, CreatedAt = DateTime.UtcNow };
            await _repository.AddAsync(blogCategory);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blogCategory = await _repository.GetAsync(b => b.Id == id);
            if (blogCategory is null) throw new KeyNotFoundException("Bloq-Kateqoriya tapılmadı!");
            _repository.Delete(blogCategory);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(BlogCategoryUpdateDTO blogCategoryUpdateDTO)
        {
            var blogCategory = await _repository.GetAsync(b=>b.Id== blogCategoryUpdateDTO.Id);
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
