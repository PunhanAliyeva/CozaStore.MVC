using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Models.Entities;

namespace CozaStore.MVC.Domain.Interfaces.IServices
{
    public interface IService<T> where T:BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

