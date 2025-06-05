
using CozaStore.MVC.Application.DTOs.SizeDTOs;
using CozaStore.MVC.Application.Exceptions;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Persistence.Services
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
            if (await _repository.AnyAsync(s => s.Name.Trim().ToLower() == sizeCreateDTO.Name.Trim().ToLower()))
                throw new ArgumentException("Bu adda ölçü artıq mövcuddur!");
            Size size = new() { Name = sizeCreateDTO.Name, CreatedAt = DateTime.UtcNow };
            await _repository.AddAsync(size);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var size=await _repository.GetByIdAsync(id);
            if(size == null) throw new KeyNotFoundException("Ölçü tapılmadı");
           _repository.Delete(size);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(SizeUpdateDTO sizeUpdateDTO)
        {
            var size = await _repository.GetByIdAsync(sizeUpdateDTO.Id);
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
