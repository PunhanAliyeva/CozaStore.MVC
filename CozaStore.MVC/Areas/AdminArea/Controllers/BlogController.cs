using CozaStore.Application.DTOs.BlogDTOs;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CozaStore.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogController(IBlogService blogService, IBlogCategoryService blogCategoryService)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithBlogCategories();
            return View(blogs);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.BlogCategories = new SelectList(await _blogCategoryService.GetAllAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateDTO blogCreateDTO)
        {
            ViewBag.BlogCategories = new SelectList(await _blogCategoryService.GetAllAsync(), "Id", "Name");
            if (!ModelState.IsValid) return View(blogCreateDTO);
            try
            {
                await _blogService.CreateAsync(blogCreateDTO);
                return RedirectToAction(nameof(Index)); 
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("Photo", ex.Message);
                return View(blogCreateDTO);                                 
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var blog=await _blogService.GetAsync(b=>b.Id==id);
            if (blog is null) return NotFound();
            return View(blog);
        }
    }
}
