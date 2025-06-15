

using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;

namespace CozaStore.Persistence.Services
{
    public class ProductImageService : Service<ProductImage>, IProductImageService
    {
        public ProductImageService(IRepository<ProductImage> repository) : base(repository)
        {

        }
    }
}
