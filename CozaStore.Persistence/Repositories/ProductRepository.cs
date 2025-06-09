using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.Persistence.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly AppDbContext _context;

		public ProductRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetFeaturedProductsAsync(int takeCount)
		{
			return await _context.Products
				.Where(p=>p.IsFeatured)
				.Include(p=>p.Category)
				.Include(p => p.ProductImages)
				.Take(takeCount)
				.ToListAsync();
		}

		public async Task<List<Product>> GetProductsWithIncludesAsync()
		{
			return await _context.Products
				.Include(p=>p.Category)
				.Include(p=>p.ProductImages)
				.ToListAsync();
		}

        public async Task<Product> GetProductByIdWithIncludesAsync(int id)
        {
			return await _context.Products
				.Include(p => p.Category)
				.Include(p=>p.ProductImages)
				.FirstOrDefaultAsync(p=>p.Id== id);	
        }
    }
}
