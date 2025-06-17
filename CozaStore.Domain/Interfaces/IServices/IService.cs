using CozaStore.Domain.Commons;
using System.Linq.Expressions;

namespace CozaStore.Domain.Interfaces.IServices
{
    public interface IService<T> where T:BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

