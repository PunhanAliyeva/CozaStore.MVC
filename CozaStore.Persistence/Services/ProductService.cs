using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class ProductService : Service<Product>, IProductService
	{
		public ProductService(IRepository<Product> repository) : base(repository)
		{

		}
	}
}
