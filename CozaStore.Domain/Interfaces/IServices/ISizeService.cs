

using CozaStore.Application.DTOs.SizeDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface ISizeService:IService<Size>
    {
        Task CreateAsync(SizeCreateDTO sizeCreateDTO);
        Task UpdateAsync(SizeUpdateDTO sizeUpdateDTO);
        Task DeleteAsync(int id);
    }
}
