using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class ProductService : Service<Product>, IProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task<List<Product>> GetProductsWithCategoryAndImagesAsync()
		{
			return await _repository.GetProductsWithCategoryAndImagesAsync();
		}
	}
}
