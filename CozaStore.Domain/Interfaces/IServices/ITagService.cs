using CozaStore.MVC.Application.DTOs.TagDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
    public interface ITagService:IService<Tag>
    {
        Task CreateAsync(TagCreateDTO tagCreateDTO);
        Task UpdateAsync(TagUpdateDTO tagUpdateDTO);
        Task DeleteAsync(int id);
    }
}
