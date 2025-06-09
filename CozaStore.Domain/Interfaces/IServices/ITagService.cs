using CozaStore.Application.DTOs.TagDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface ITagService:IService<Tag>
    {
        Task CreateAsync(TagCreateDTO tagCreateDTO);
        Task UpdateAsync(TagUpdateDTO tagUpdateDTO);
        Task DeleteAsync(int id);
    }
}
