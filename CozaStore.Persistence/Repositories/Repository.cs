using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CozaStore.MVC.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table=_context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTime.UtcNow;
            _table.Update(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.Where(t => t.DeletedAt == null).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(t=> t.Id == id && t.DeletedAt==null);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.AnyAsync(predicate);
        }
    }
}
