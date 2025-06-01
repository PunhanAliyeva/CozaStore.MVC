using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStore.MVC.Entities
{
    public class Product:BaseEntity
	{
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        [NotMapped]
		public string? MainImageUrl => ProductImages.Count > 0 ? (ProductImages.Any(p => p.IsMain) ?
		   ProductImages.FirstOrDefault(p => p.IsMain).ImageUrl :
		   ProductImages.FirstOrDefault().ImageUrl) : null;
		public List<ProductSizes> ProductSizes { get; set; }
		public List<ProductColors> ProductColors { get; set; }
		public List<ProductTags> ProductTags { get; set; }
        public Product()
        {
            ProductImages = new();
        }
    }
}
