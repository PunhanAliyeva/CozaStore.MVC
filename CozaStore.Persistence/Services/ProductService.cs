using CozaStore.Application.DTOs;
using CozaStore.Application.DTOs.ProductDTOs;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Infrastructure.Extensions;
using CozaStore.Persistence.Helpers;
using CozaStore.Persistence.Repositories;

namespace CozaStore.Persistence.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(ProductCreateDTO productCreateDTO)
        {
            if (productCreateDTO.Name is null) throw new ArgumentException("Məhsul adı əlavə et!");
            var photos = productCreateDTO.Photos;
            if (photos.Length == 0)
                throw new ArgumentException("Şəkil əlavə et!");
            Product newProduct = new();
            foreach (var photo in photos)
            {
                if (!photo.CheckImage())
                {
                    throw new ArgumentException("Yalniz şəkil göndərilə bilər!");
                }
                if (photo.CheckImageSize(2000))
                {
                    throw new ArgumentException("Şəklin ölçüsü 2MB-dan çox olmamalıdır!");
                }
                ProductImage productImage = new();
                productImage.ImageUrl = photo.SaveFile("uploads", "images");
                productImage.ProductId = newProduct.Id;
                if (photos[0] == photo)
                {
                    productImage.IsMain = true;
                }
                newProduct.ProductImages.Add(productImage);
            }
            newProduct.Name = productCreateDTO.Name;
            newProduct.Price = productCreateDTO.Price;
            newProduct.Description = productCreateDTO.Description;
            newProduct.CategoryId = productCreateDTO.CategoryId;
            await _repository.AddAsync(newProduct);
            await _repository.SaveAsync();
        }

        public async Task<List<ProductGetDTO>> GetFeaturedProductsAsync(int takeCount)
        {
            var products = await _repository.GetFeaturedProductsAsync(takeCount);
            return products.Select(p => new ProductGetDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description=p.Description,
                Price = p.Price,
                CategoryName = p.Category.Name,
                ImageUrls = p.ProductImages?.Select(i => i.ImageUrl).ToList() ?? new List<string>()
            }).ToList();
        }

        public async Task<List<ProductGetDTO>> GetProductsWithIncludesAsync()
        {
            var products= await _repository.GetProductsWithIncludesAsync();
            var dtoList = products.Select(p => new ProductGetDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description=p.Description,
                Price = p.Price,
                CategoryName = p.Category?.Name,
                ImageUrls = p.ProductImages?.Select(i => i.ImageUrl).ToList() ?? new List<string>(),
                CreatedAt=p.CreatedAt,
                ModifiedAt=p.UpdatedAt
            }).ToList();
            return dtoList;
        }

        public async Task<Product> GetProductByIdWithIncludesAsync(int id)
        {
            var product = await _repository.GetProductByIdWithIncludesAsync(id);
            if (product == null) throw new KeyNotFoundException("Məhsul mövcud deyil!");
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product =await  _repository.GetProductByIdWithIncludesAsync(id);
            if (product is null) throw new KeyNotFoundException("Məhsul tapılmadı!");
            _repository.Delete(product);
            foreach (var image in product.ProductImages)
            {
                FileHelper.DeleteFile("uploads","images", image.ImageUrl);
            }
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(ProductUpdateDTO productUpdateDTO)
        {
            var product =await _repository.GetProductByIdWithIncludesAsync(productUpdateDTO.Id);
            if (product is null) throw new KeyNotFoundException("Məhsul tapılmadı!");
            product.Name= productUpdateDTO.Name;
            product.Description= productUpdateDTO.Description;
            product.Price= productUpdateDTO.Price;
            product.CategoryId= productUpdateDTO.CategoryId;
            product.IsFeatured = productUpdateDTO.IsFeatured;
            if (productUpdateDTO.Photos != null)
            {
                foreach (var photo in productUpdateDTO.Photos)
                {
                    if (!photo.CheckImage())
                    {
                        throw new ArgumentException("Yalniz şəkil göndərilə bilər!");
                    }
                    if (photo.CheckImageSize(2000))
                    {   
                        throw new ArgumentException("Şəklin ölçüsü 2MB-dan çox olmamalıdır!");
                    }
                    string fileName = photo.SaveFile("uploads","images"); 
                    product.ProductImages.Add(new ProductImage
                    {
                        ProductId=product.Id,
                        ImageUrl = fileName,
                        IsMain = false 
                    });
                }
            }
            // Köhnə şəkillərin isMain statusunu yenilə
            foreach (var image in product.ProductImages)
            {
                var updatedImage = productUpdateDTO.ProductImages.FirstOrDefault(pi => pi.Id == image.Id);
                if (updatedImage != null)
                {
                    image.IsMain = updatedImage.IsMain;
                }
            }
            _repository.Update(product);
            product.UpdatedAt= DateTime.UtcNow;
            await _repository.SaveAsync();
        }


    }
}
