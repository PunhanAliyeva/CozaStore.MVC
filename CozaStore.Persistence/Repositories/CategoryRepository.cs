using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
		private readonly AppDbContext _context;

		public CategoryRepository(AppDbContext context) : base(context)
        {
			_context = context;
		}

		public async Task<List<Category>> GetCategoriesWithIncludesAsync()
		{
			return await _context.Categories
				.Include(c=>c.Parent)
			    .Where(c => c.DeletedAt == null)
				.ToListAsync();
		}

		public async Task<Category> GetCategoriesWithIncludesAsync(int id)
		{
			return await _context.Categories
				.Include(c => c.Parent)
				.FirstOrDefaultAsync(c=>c.Id==id && c.DeletedAt==null);
		}
	}
}
