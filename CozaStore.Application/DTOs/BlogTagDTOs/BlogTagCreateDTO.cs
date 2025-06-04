

using System.ComponentModel.DataAnnotations;

namespace CozaStore.MVC.Application.DTOs.BlogTagDTOs
{
	public class BlogTagCreateDTO
	{
		[Required, StringLength(30)]
		public string Name { get; set; }
    }
}
