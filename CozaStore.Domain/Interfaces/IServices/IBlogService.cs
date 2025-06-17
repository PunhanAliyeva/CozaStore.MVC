using CozaStore.Application.DTOs.BlogCategoryDTOs;
using CozaStore.Application.DTOs.BlogDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
	public interface IBlogService:IService<Blog>
	{
		Task<List<Blog>> GetBlogsWithBlogCategories();
		Task CreateAsync(BlogCreateDTO blogCreateDTO);
	}
}
