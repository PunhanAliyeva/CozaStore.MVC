using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Models.Entities;
using CozaStore.MVC.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Where(c => c.DeletedAt == null).ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.DeletedAt == null);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            category.DeletedAt = DateTime.UtcNow;
            _context.Categories.Update(category);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
