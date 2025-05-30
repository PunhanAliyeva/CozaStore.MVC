using CozaStore.MVC.Entities;

namespace CozaStore.MVC.ViewModels
{
	public class BlogVM
	{
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
