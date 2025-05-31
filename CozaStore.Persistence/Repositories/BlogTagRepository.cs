using CozaStore.MVC.Domain.Entities;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
	public class BlogTagRepository : Repository<BlogTag>, IBlogTagRepository
	{
		public BlogTagRepository(AppDbContext context) : base(context)
		{

		}
	}
}
