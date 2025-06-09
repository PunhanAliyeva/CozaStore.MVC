using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Persistence.Data;

namespace CozaStore.Persistence.Repositories
{
	public class BlogTagRepository : Repository<BlogTag>, IBlogTagRepository
	{
		public BlogTagRepository(AppDbContext context) : base(context)
		{

		}
	}
}
