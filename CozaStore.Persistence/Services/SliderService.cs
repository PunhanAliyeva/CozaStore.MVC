using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.MVC.Persistence.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        public async Task<List<Slider>> GetAllAsync()
        {
            return await _sliderRepository.GetAllAsync();
        }
        public async Task<Slider?> GetByIdAsync(int id)
        {
            return await _sliderRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Slider slider)
        {
            await _sliderRepository.AddAsync(slider);
            await _sliderRepository.SaveAsync();
        }

        public async Task UpdateAsync(Slider slider)
        {
            _sliderRepository.Update(slider);
            await _sliderRepository.SaveAsync();
        }

        public async Task DeleteAsync(Slider slider)
        {
            slider.DeletedAt = DateTime.UtcNow;
            _sliderRepository.Update(slider);
            await _sliderRepository.SaveAsync();
        }
    }
}
