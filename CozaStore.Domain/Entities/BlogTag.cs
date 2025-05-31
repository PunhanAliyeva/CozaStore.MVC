using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Entities
{
	public class BlogTag:BaseEntity
	{
        public string Name { get; set; }
		public List<BlogTags> BlogTags { get; set; }
	}
}
