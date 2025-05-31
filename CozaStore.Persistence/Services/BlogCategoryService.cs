using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class BlogCategoryService : Service<BlogCategory>, IBlogCategoryService
	{
		public BlogCategoryService(IRepository<BlogCategory> repository) : base(repository)
		{

		}
	}
}
