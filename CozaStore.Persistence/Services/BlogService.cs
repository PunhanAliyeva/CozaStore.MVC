using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;

namespace CozaStore.Persistence.Services
{
	public class BlogService : Service<Blog>, IBlogService
	{
		private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository):base(repository) 
        {
            _repository = repository;
        }

        public async Task<List<Blog>> GetBlogsWithBlogCategories()
        {
            return await _repository.GetBlogsWithBlogCategories();
        }
    }
}
