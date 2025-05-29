using CozaStore.MVC.Models.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IRepositories
{
    public interface ISliderRepository
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider?> GetByIdAsync(int id);
        Task AddAsync(Slider slider);
        void Update(Slider slider);
        void Delete(Slider slider);
        Task SaveAsync();
    }
}
