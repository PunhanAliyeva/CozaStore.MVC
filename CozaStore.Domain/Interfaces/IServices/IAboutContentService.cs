using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
	public interface IAboutContentService:IService<AboutContent>
	{
		Task<AboutContent?> GetFirstAsync();
	}
}
