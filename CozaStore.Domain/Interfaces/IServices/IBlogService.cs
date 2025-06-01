using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IBlogService:IService<Blog>
	{
		Task<List<Blog>> GetBlogsWithBlogCategories();
	}
}
