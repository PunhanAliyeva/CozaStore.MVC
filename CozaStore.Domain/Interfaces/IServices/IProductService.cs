using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IProductService : IService<Product>
	{
		Task<List<Product>> GetProductsWithCategoryAndImagesAsync();
	}
}
