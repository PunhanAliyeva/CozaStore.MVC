using CozaStore.Domain.Commons;
using System.Linq.Expressions;

namespace CozaStore.Domain.Interfaces.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task HardDeleteAsync(T entity);  
        Task SaveAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}

