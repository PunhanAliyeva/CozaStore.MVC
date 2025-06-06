
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.CategoryDTOs
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string Concept { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? Photo { get; set; }
        public int? ParentId { get; set; }
    }
}
