using CozaStore.Application.DTOs.BlogTagDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
	public interface IBlogTagService:IService<BlogTag>
	{
		Task CreateAsync(BlogTagCreateDTO blogTagCreateDTO);
		Task UpdateAsync(BlogTagUpdateDTO blogTagUpdateDTO);
		Task DeleteAsync(int id);
	}
}
