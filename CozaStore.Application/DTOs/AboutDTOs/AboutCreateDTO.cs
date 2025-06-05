

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.AboutDTOs
{
    public class AboutCreateDTO
    {
        [Required,StringLength(30)]
        public string Title { get; set; }
        [Required, StringLength(30)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa şəkil əlavə edin!")]
        public IFormFile Photo { get; set; }

    }
}
