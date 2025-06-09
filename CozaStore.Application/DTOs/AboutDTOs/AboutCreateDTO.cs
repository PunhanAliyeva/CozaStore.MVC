

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.Application.DTOs.AboutDTOs
{
    public class AboutCreateDTO
    {
        [Required,StringLength(30)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa şəkil əlavə edin!")]
        public IFormFile Photo { get; set; }

    }
}
