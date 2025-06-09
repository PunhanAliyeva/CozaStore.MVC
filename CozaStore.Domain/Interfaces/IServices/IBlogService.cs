using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
	public interface IBlogService:IService<Blog>
	{
		Task<List<Blog>> GetBlogsWithBlogCategories();
	}
}
