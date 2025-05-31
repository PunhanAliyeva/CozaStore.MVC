
using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Domain.Entities;

namespace CozaStore.MVC.Entities
{
	public class BlogTags:BaseEntity
	{
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }
    }
}
