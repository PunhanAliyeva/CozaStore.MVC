
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Models.Entities
{
    public class BlogCategory:BaseEntity
	{
        public string Name { get; set; }
        public List<Blog>Blogs { get; set; }
    }
}
