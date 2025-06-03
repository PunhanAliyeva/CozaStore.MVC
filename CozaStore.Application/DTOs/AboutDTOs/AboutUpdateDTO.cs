
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.AboutDTOs
{
    public class AboutUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
