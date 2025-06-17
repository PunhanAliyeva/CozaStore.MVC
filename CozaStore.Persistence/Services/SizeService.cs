
using CozaStore.Application.DTOs.SizeDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;

namespace CozaStore.Persistence.Services
{
    public class SizeService : Service<Size>, ISizeService
    {
        private readonly IRepository<Size> _repository;

        public SizeService(IRepository<Size> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(SizeCreateDTO sizeCreateDTO)
        {
            if (string.IsNullOrWhiteSpace(sizeCreateDTO.Name))
                throw new ArgumentException("Ölçü adı boş ola bilməz!");
            if (await _repository.AnyAsync(s => s.Name.ToLower() == sizeCreateDTO.Name.ToLower() && s.DeletedAt==null))
                throw new ArgumentException("Bu adda ölçü artıq mövcuddur!");
            Size size = new() { Name = sizeCreateDTO.Name, CreatedAt = DateTime.UtcNow };
            await _repository.AddAsync(size);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var size=await _repository.GetAsync(s=>s.Id==id);
            if(size == null) throw new KeyNotFoundException("Ölçü tapılmadı");
           _repository.Delete(size);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(SizeUpdateDTO sizeUpdateDTO)
        {
            var size = await _repository.GetAsync(s=>s.Id==sizeUpdateDTO.Id);
            if (size == null) throw new KeyNotFoundException("Ölçü tapılmadı");
            var isExist = await _repository.AnyAsync(s => s.Name.Trim().ToLower() == sizeUpdateDTO.Name.Trim().ToLower() && s.Id != sizeUpdateDTO.Id);
            if (isExist) throw new ValidationException("Name", "Eyniadlı ölçü əlavə etmək olmaz!");
            size.Name = sizeUpdateDTO.Name;
            size.UpdatedAt = DateTime.UtcNow;
            _repository.Update(size);
            await _repository.SaveAsync();
        }
    }
}
