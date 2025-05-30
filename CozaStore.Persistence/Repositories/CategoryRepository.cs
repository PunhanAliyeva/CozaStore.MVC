using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
