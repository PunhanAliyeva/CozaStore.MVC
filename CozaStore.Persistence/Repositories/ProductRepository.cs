using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Repositories
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
				.Include(p => p.ProductImages)
				.Take(takeCount)
				.ToListAsync();
		}

		public async Task<List<Product>> GetProductsWithCategoryAndImagesAsync()
		{
			return await _context.Products
				.Include(p=>p.Category)
				.Include(p=>p.ProductImages)
				.ToListAsync();
		}
	}
}
