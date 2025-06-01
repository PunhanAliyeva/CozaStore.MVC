using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Repositories
{
	public class AboutRepository : Repository<About>, IAboutRepository
	{
		private readonly AppDbContext _context;

		public AboutRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task<About> GetFirstAsync()
		{
			return await _context.Abouts.FirstOrDefaultAsync();
		}
	}
}
