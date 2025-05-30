using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;
using CozaStore.MVC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Repositories
{
	public class AboutContentRepository : Repository<AboutContent>, IAboutContentRepository
	{
		private readonly AppDbContext _context;
		public AboutContentRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<AboutContent?> GetFirstAsync()
		{
			return await _context.AboutContents.FirstOrDefaultAsync();
		}
	}
}
