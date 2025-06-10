using Microsoft.AspNetCore.Http;

namespace CozaStore.Application.DTOs.ProductDTOs
{
	public class ProductGetDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public List<string> ImageUrls { get; set; }
        public string? MainImageUrl =>ImageUrls != null && ImageUrls.Count > 0 ? ImageUrls.FirstOrDefault() : null;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
