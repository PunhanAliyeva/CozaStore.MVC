
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class BlogTags:BaseEntity
	{
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }
    }
}
