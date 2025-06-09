using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Persistence.Data;

namespace CozaStore.Persistence.Repositories
{
	public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
	{
		public BlogCategoryRepository(AppDbContext context) : base(context)
		{

		}
	}
}
