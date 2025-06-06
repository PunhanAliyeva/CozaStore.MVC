using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IRepositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
		Task<List<Category>> GetCategoriesWithIncludesAsync();
		Task<Category> GetCategoriesWithIncludesAsync(int id);
	}
}
