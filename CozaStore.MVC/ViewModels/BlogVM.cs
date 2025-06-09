using CozaStore.Application.DTOs.ProductDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.MVC.ViewModels
{
	public class BlogVM
	{
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<ProductGetDTO> FeaturedProducts { get; set; }
        public IEnumerable<BlogCategory> BlogCategories { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }
    }
}
