using CozaStore.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStore.Domain.Entities
{
    public class About: BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		[NotMapped]
		public string ShortDesc => Description.Length > 40 ? Description.Substring(0, 40) + "..." : Description;   
		public string ImageUrl { get; set; }
	}
}
