using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class BlogService : Service<Blog>, IBlogService
	{
		private readonly IBlogRepository _repository;

		public BlogService(IBlogRepository repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task<List<Blog>> GetBlogsWithBlogCategories()
		{
			return await _repository.GetBlogsWithBlogCategories();
		}
	}
}
