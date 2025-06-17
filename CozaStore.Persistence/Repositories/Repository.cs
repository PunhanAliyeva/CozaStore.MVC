using CozaStore.Domain.Commons;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CozaStore.Persistence.Repositories
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

        public async Task HardDeleteAsync(T entity)
        {
           _table.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _table.Where(t => t.DeletedAt == null).ToListAsync();
            }
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _table.Where(t => t.DeletedAt == null).FirstOrDefaultAsync();
            }
            return await _table.Where(predicate).FirstOrDefaultAsync(p=>p.DeletedAt==null);
        }
    }
}
