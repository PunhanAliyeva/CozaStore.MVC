using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IRepositories
{
	public interface IBlogRepository:IRepository<Blog>
	{
		Task<List<Blog>> GetBlogsWithBlogCategories();
	}
}
