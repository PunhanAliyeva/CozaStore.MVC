using CozaStore.MVC.Application.DTOs.ProductDTOs;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Infrastructure.Extensions;
using System.Collections.Immutable;

namespace CozaStore.MVC.Persistence.Services
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
                productImage.ImageUrl = photo.SaveFile("uploads","images");
                productImage.ProductId = newProduct.Id;
                if (photos[0] == photo)
                {
                    productImage.IsMain = true;
                }
                newProduct.ProductImages.Add(productImage);
            }
            newProduct.Name = productCreateDTO.Name;
            newProduct.Price = productCreateDTO.Price;
            newProduct.CategoryId = productCreateDTO.CategoryId;
            await _repository.AddAsync(newProduct);
            await _repository.SaveAsync();
        }

        public async Task<List<Product>> GetFeaturedProductsAsync(int takeCount)
		{
			return await _repository.GetFeaturedProductsAsync(takeCount);
		}

		public async Task<List<Product>> GetProductsWithIncludesAsync()
		{
			return await _repository.GetProductsWithIncludesAsync();
		}
	}
}
