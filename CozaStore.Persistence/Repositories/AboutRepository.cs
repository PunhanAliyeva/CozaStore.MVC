using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context)
        {

        }
    }
}
