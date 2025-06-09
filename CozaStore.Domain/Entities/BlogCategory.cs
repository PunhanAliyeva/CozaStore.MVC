
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
    public class BlogCategory:BaseEntity
	{
        public string Name { get; set; }
        public List<Blog>Blogs { get; set; }
    }
}
