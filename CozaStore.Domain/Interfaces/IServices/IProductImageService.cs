

using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface IProductImageService:IService<ProductImage>
    {
        Task HardDeleteImageAsync(ProductImage image);
    }
}
