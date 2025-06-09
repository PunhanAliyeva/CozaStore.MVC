
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.Persistence.Repositories
{
	public class BlogRepository : Repository<Blog>, IBlogRepository
	{
		private readonly AppDbContext _context;

		public BlogRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Blog>> GetBlogsWithBlogCategories()
		{
			return await _context.Blogs
				.Include(b=>b.BlogCategory)
				.ToListAsync();
		}
	}
}
