using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IRepositories
{
	public interface IProductRepository:IRepository<Product>
	{
		Task<List<Product>> GetProductsWithIncludesAsync();
		Task<List<Product>> GetFeaturedProductsAsync(int takeCount);
	}
}
