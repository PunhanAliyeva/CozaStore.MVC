using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
	public class BlogRepository : Repository<Blog>, IBlogRepository
	{
		public BlogRepository(AppDbContext context) : base(context)
		{

		}
	}
}
