using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Domain.Interfaces.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}

