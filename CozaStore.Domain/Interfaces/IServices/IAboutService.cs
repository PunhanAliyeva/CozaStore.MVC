using CozaStore.Application.DTOs.AboutDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Interfaces.IServices
{
	public interface IAboutService:IService<About>
	{
		Task CreateAsync(AboutCreateDTO aboutCreateDTO);
		Task UpdateAsync(AboutUpdateDTO aboutUpdateDTO);
		Task DeleteAsync(int id);
	}
}
