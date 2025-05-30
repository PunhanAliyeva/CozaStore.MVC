
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class Tag:BaseEntity
	{
        public string Name { get; set; }
		public List<BlogTags> BlogTags { get; set; }
	}
}
