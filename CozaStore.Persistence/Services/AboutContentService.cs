using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
{
	public class AboutContentService : Service<AboutContent>, IAboutContentService
	{
		private readonly IAboutContentRepository _repository;

		public AboutContentService(IAboutContentRepository repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task<AboutContent> GetFirstAsync()
		{
			return await _repository.GetFirstAsync();
		}
	}
}
