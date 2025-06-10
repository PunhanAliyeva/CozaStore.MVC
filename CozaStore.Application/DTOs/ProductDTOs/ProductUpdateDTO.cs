
using Microsoft.AspNetCore.Http;

namespace CozaStore.Application.DTOs.ProductDTOs
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile[]? Photos { get; set; }
        public List<ProductImageDTO> ProductImages { get; set; }
    }
}
