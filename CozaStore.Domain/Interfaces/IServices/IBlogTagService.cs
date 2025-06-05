using CozaStore.MVC.Application.DTOs.BlogTagDTOs;
using CozaStore.MVC.Domain.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IBlogTagService:IService<BlogTag>
	{
		Task CreateAsync(BlogTagCreateDTO blogTagCreateDTO);
		Task UpdateAsync(BlogTagUpdateDTO blogTagUpdateDTO);
		Task DeleteAsync(int id);
	}
}
