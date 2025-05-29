using CozaStore.MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider?> GetByIdAsync(int id);
        Task AddAsync(Slider slider);
        Task UpdateAsync(Slider slider);
        Task DeleteAsync(Slider slider);
    }
}
