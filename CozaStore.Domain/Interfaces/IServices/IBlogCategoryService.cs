using CozaStore.MVC.Application.DTOs.BlogCategoryDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IBlogCategoryService:IService<BlogCategory>
	{
		Task CreateAsync(BlogCategoryCreateDTO blogCategoryCreateDTOn);
		Task UpdateAsync(BlogCategoryUpdateDTO blogCategoryUpdateDTOn);
		Task DeleteAsync(int id);
	}
}
