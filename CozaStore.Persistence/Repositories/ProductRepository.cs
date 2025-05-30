using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Models.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
		{

		}
	}
}
