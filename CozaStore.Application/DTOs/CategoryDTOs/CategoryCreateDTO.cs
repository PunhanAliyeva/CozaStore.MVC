
using Microsoft.AspNetCore.Http;

namespace CozaStore.MVC.Application.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Concept { get; set; }
        public IFormFile Photo { get; set; }
        public int? ParentId { get; set; }
    }
}
