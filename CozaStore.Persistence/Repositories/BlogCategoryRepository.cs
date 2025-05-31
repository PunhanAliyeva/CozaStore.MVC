using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
	public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
	{
		public BlogCategoryRepository(AppDbContext context) : base(context)
		{

		}
	}
}
