using CozaStore.Domain.Entities;
using CozaStore.Application.DTOs.ProductDTOs;

namespace CozaStore.Domain.Interfaces.IServices
{
	public interface IProductService : IService<Product>
	{
		Task<List<ProductGetDTO>> GetProductsWithIncludesAsync();
        Task<Product> GetProductByIdWithIncludesAsync(int id);
        Task<List<ProductGetDTO>> GetFeaturedProductsAsync(int takeCount);
		Task CreateAsync(ProductCreateDTO productCreateDTO);
		Task UpdateAsync(ProductUpdateDTO productUpdateDTO);
		Task DeleteAsync(int id);
    }
}
