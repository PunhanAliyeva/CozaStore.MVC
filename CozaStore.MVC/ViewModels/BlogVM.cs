using CozaStore.MVC.Domain.Entities;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.ViewModels
{
	public class BlogVM
	{
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<BlogCategory> BlogCategories { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }
    }
}
