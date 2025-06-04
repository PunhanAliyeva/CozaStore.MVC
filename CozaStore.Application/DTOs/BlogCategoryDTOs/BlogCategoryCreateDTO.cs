using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.BlogCategoryDTOs
{
    public class BlogCategoryCreateDTO
    {
        [Required,StringLength(30)]
        public string Name { get; set; }
    }
}
