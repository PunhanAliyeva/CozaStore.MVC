

using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;

namespace CozaStore.Persistence.Services
{
    public class ProductImageService : Service<ProductImage>, IProductImageService
    {
        private readonly IRepository<ProductImage> _repository;

        public ProductImageService(IRepository<ProductImage> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task HardDeleteImageAsync(ProductImage image)
        {
            await _repository.HardDeleteAsync(image);
            await _repository.SaveAsync();
        }
    }
}
