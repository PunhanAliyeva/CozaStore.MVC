
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
		[Required, StringLength(30)]
		public string Name { get; set; }
		[Required, StringLength(40)]
		public string Concept { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa şəkil əlavə edin!")]
		public IFormFile Photo { get; set; }
        public int? ParentId { get; set; }
    }
}
