using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;


namespace CozaStore.MVC.Persistence.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
