
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Models.Entities
{
    public class About: BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
