
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.Application.DTOs.BlogDTOs
{
    public class BlogCreateDTO
    {
        [Required,StringLength(40)]
        public string Concept { get; set; }
        public string? Description { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public string? AuthorName { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
