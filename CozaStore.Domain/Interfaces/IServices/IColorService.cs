
using CozaStore.MVC.Application.DTOs.ColorDTOs;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface IColorService:IService<Color>
    {
        Task CreateAsync(ColorCreateDTO colorCreateDTO);
        Task UpdateAsync(ColorUpdateDTO colorUpdateDTO);
        Task DeleteAsync(int id);
    }
}
