using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Services
{
	public class AboutService : Service<About>, IAboutService
	{
		private readonly IAboutRepository _repository;

		public AboutService(IAboutRepository repository) : base(repository)
		{
			_repository = repository;
		}
		public async Task<About?> GetFirstAsync()
		{
			return await _repository.GetFirstAsync();
		}
	}
}
