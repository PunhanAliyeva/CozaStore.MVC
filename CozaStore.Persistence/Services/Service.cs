using CozaStore.Domain.Commons;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using System.Linq.Expressions;

namespace CozaStore.Persistence.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _repository.SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate == null) return await _repository.GetAllAsync();
            return await _repository.GetAllAsync(predicate);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate is null) return await _repository.GetAsync();
            return await _repository.GetAsync(predicate);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(r=>r.Id==id); 
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
        }
    }
}
