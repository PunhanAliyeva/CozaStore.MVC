using CozaStore.MVC.Application.DTOs.CategoryDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
    public interface ICategoryService:IService<Category>
    {
        Task CreateAsync(CategoryCreateDTO categoryCreateDTO);
        Task DeleteAsync(int id);
        Task<List<CategoryGetDTO>> GetCategoriesWithIncludesAsync();
        Task<CategoryGetDTO> GetCategoriesWithIncludesAsync(int id);
	}
}
