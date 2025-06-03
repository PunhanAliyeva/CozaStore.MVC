using CozaStore.MVC.Application.DTOs.AboutDTOs;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IAboutService:IService<About>
	{
		Task CreateAsync(AboutCreateDTO aboutCreateDTO);
		Task UpdateAsync(AboutUpdateDTO aboutUpdateDTO);
	}
}
