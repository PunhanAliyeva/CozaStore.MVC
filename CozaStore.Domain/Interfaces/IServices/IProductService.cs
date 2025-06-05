using CozaStore.MVC.Application.DTOs.ProductDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IProductService : IService<Product>
	{
		Task<List<Product>> GetProductsWithIncludesAsync();
		Task<List<Product>> GetFeaturedProductsAsync(int takeCount);
		Task CreateAsync(ProductCreateDTO productCreateDTO);
	}
}
