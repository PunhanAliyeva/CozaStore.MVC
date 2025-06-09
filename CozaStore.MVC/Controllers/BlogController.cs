using CozaStore.Domain.Interfaces.IServices;
using CozaStore.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.MVC.Controllers
{
    public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
		private readonly IProductService _productService;
		private readonly IBlogCategoryService _blogCategoryService;
		private readonly IBlogTagService _blogTagService;

		public BlogController(IBlogService blogService, IProductService productService, IBlogCategoryService blogCategoryService, IBlogTagService blogTagService)
		{
			_blogService = blogService;
			_productService = productService;
			_blogCategoryService = blogCategoryService;
			_blogTagService = blogTagService;
		}
		public async Task<IActionResult> Index()
		{
			BlogVM blogVM = new()
			{
				Blogs = await _blogService.GetBlogsWithBlogCategories(),
				FeaturedProducts = await _productService.GetFeaturedProductsAsync(3),
				BlogCategories = await _blogCategoryService.GetAllAsync(),
				BlogTags = await _blogTagService.GetAllAsync()
			};
			return View(blogVM);
		}
	}
}
