using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {

        }
    }
}

