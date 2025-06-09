using CozaStore.Domain.Commons;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Entities
{
	public class BlogTag:BaseEntity
	{
        public string Name { get; set; }
		public List<BlogTags> BlogTags { get; set; }
	}
}
