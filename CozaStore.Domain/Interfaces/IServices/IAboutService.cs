using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IAboutService:IService<About>
	{
		Task<About> GetFirstAsync();
	}
}
