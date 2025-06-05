
using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.SizeDTOs
{
    public class SizeCreateDTO
    {
        [Required,StringLength(10)]
        public string Name { get; set; }
    }
}
