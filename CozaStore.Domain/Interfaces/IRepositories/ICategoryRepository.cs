using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IRepositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
		Task<List<Category>> GetCategoriesWithIncludesAsync();
		Task<Category> GetCategoriesWithIncludesAsync(int id);
	}
}
