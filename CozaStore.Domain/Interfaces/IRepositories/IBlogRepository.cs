using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IRepositories
{
	public interface IBlogRepository:IRepository<Blog>
	{
		Task<List<Blog>> GetBlogsWithBlogCategories();
	}
}
