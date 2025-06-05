
using CozaStore.MVC.Application.DTOs.ColorDTOs;
using CozaStore.MVC.Application.DTOs.SizeDTOs;
using CozaStore.MVC.Application.DTOs.TagDTOs;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Domain.Interfaces.IServices;
using CozaStore.MVC.Entities;
using CozaStore.MVC.Persistence.Repositories;

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
    }
}
