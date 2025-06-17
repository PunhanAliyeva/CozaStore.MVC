using CozaStore.Application.DTOs.BlogDTOs;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Infrastructure.Extensions;


namespace CozaStore.Persistence.Services
{
	public class BlogService : Service<Blog>, IBlogService
	{
		private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository):base(repository) 
        {
            _repository = repository;
        }

        public async Task CreateAsync(BlogCreateDTO blogCreateDTO)
        {
            if (blogCreateDTO.Photo == null || blogCreateDTO.Photo.Length == 0)
                throw new ArgumentException("Şəkil boş ola bilməz!");

            if (!blogCreateDTO.Photo.CheckImage())
                throw new ArgumentException("Yalnız şəkil göndərilə bilər!");

            if (blogCreateDTO.Photo.CheckImageSize(2000))
                throw new ArgumentException("Şəklin ölçüsü 2MB-dan böyükdür!");

            string fileName = blogCreateDTO.Photo.SaveFile("uploads", "images");
            Blog blog = new() { Concept = blogCreateDTO.Concept,BlogCategoryId=blogCreateDTO.BlogCategoryId, Description = blogCreateDTO.Description, ImageUrl = fileName, CreatedAt = DateTime.UtcNow };
            await _repository.AddAsync(blog);
            await _repository.SaveAsync();
        }

        public async Task<List<Blog>> GetBlogsWithBlogCategories()
        {
            return await _repository.GetBlogsWithBlogCategories();
        }
    }
}
