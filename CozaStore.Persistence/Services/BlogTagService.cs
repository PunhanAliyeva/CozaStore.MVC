using CozaStore.MVC.Domain.Entities;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class BlogTagService : Service<BlogTag>, IBlogTagService
	{
		public BlogTagService(IRepository<BlogTag> repository) : base(repository)
		{
		}
	}
}
