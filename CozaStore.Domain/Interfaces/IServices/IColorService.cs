
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Domain.Entities;
using CozaStore.Application.DTOs.ColorDTOs;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface IColorService:IService<Color>
    {
        Task CreateAsync(ColorCreateDTO colorCreateDTO);
        Task UpdateAsync(ColorUpdateDTO colorUpdateDTO);
        Task DeleteAsync(int id);
    }
}
