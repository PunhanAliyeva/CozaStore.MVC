using Microsoft.AspNetCore.Http;

namespace CozaStore.Application.DTOs.SliderDTOs
{
    public class SliderUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IFormFile? Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
