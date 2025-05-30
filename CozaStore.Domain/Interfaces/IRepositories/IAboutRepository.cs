using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IRepositories
{
	public interface IAboutRepository:IRepository<About>
	{
		Task<About?> GetFirstAsync();
	}
}
