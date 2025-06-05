
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
