

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.Application.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
		[Required, StringLength(30)]
		public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public IFormFile[] Photos { get; set; }
    }
}
