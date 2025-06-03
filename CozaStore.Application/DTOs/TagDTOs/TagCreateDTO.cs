using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.TagDTOs
{
    public class TagCreateDTO
    {
        [Required, StringLength(30)]
        public string Name { get; set; }
    }
}
