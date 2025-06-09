
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IRepositories
{
	public interface IProductRepository:IRepository<Product>
	{
		Task<List<Product>> GetProductsWithIncludesAsync();
		Task<Product> GetProductByIdWithIncludesAsync(int id);
		Task<List<Product>> GetFeaturedProductsAsync(int takeCount);
	}
}
