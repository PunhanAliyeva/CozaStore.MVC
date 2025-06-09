using System.ComponentModel.DataAnnotations;

namespace CozaStore.Application.DTOs.BlogCategoryDTOs
{
    public class BlogCategoryCreateDTO
    {
        [Required,StringLength(30)]
        public string Name { get; set; }
    }
}
