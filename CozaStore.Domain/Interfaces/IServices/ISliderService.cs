using CozaStore.MVC.Application.DTOs.SliderDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
    public interface ISliderService:IService<Slider>
    {
        Task CreateAsync(SliderCreateDTO sliderCreateDTO);
        Task UpdateAsync(SliderUpdateDTO sliderUpdateDTO);
    }
}
