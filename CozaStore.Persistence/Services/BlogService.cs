using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class BlogService : Service<Blog>, IBlogService
	{
		public BlogService(IRepository<Blog> repository) : base(repository)
		{

		}
	}
}
