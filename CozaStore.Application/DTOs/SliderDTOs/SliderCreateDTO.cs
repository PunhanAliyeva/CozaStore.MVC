using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.SliderDTOs
{
	public class SliderCreateDTO
	{
		[Required, StringLength(30)]
		public string Title { get; set; }
		[Required, StringLength(30)]
		public string SubTitle { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa şəkil əlavə edin!")]
		public IFormFile Photo { get; set; }
	}
}
