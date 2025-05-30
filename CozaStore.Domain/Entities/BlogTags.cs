
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class BlogTags:BaseEntity
	{
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
