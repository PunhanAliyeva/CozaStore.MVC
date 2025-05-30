using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
    public class SliderService : Service<Slider>, ISliderService
    {
        public SliderService(IRepository<Slider> repository) : base(repository)
        {

        }
    }
}
