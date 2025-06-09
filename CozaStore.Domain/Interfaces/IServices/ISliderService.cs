using CozaStore.Application.DTOs.SliderDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface ISliderService:IService<Slider>
    {
        Task CreateAsync(SliderCreateDTO sliderCreateDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(SliderUpdateDTO sliderUpdateDTO);
    }
}
