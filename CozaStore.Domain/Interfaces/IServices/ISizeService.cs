

using CozaStore.MVC.Application.DTOs.SizeDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
    public interface ISizeService:IService<Size>
    {
        Task CreateAsync(SizeCreateDTO sizeCreateDTO);
    }
}
