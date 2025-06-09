using System.ComponentModel.DataAnnotations;

namespace CozaStore.Application.DTOs.TagDTOs
{
    public class TagCreateDTO
    {
        [Required, StringLength(30)]
        public string Name { get; set; }
    }
}
