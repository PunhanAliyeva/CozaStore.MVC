using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Models.Entities;
using CozaStore.MVC.Persistence.Data;

namespace CozaStore.MVC.Persistence.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext context) : base(context)
        {

        }
    }
}
