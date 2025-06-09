

using System.ComponentModel.DataAnnotations;

namespace CozaStore.Application.DTOs.ColorDTOs
{
    public class ColorCreateDTO
    {
        [Required,StringLength(30)]
        public string Name { get; set; }
    }
}
