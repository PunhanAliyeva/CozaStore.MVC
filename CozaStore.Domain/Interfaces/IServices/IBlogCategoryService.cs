using CozaStore.Application.DTOs.BlogCategoryDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
	public interface IBlogCategoryService:IService<BlogCategory>
	{
		Task CreateAsync(BlogCategoryCreateDTO blogCategoryCreateDTOn);
		Task UpdateAsync(BlogCategoryUpdateDTO blogCategoryUpdateDTOn);
		Task DeleteAsync(int id);
	}
}
