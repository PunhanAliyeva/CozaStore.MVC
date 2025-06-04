
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.MVC.Application.DTOs.ColorDTOs;
using CozaStore.MVC.Application.DTOs.TagDTOs;
using CozaStore.MVC.Application.Exceptions;
using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Entities;
using System.Diagnostics.Metrics;

namespace CozaStore.MVC.Persistence.Services
{
    public class ColorService : Service<Color>, IColorService
    {
        private readonly IRepository<Color> _repository;

        public ColorService(IRepository<Color> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(ColorCreateDTO colorCreateDTO)
        {
            if (string.IsNullOrWhiteSpace(colorCreateDTO.Name))
                throw new ArgumentException("Rəng adı boş ola bilməz!");
            if (await _repository.AnyAsync(c => c.Name.Trim().ToLower() == colorCreateDTO.Name.Trim().ToLower()))
                throw new ArgumentException("Bu adda rəng artıq mövcuddur!");
            Color color = new() { Name = colorCreateDTO.Name, CreatedAt = DateTime.UtcNow };
            await _repository.AddAsync(color);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var color = await _repository.GetByIdAsync(id);
            if (color == null) throw new KeyNotFoundException("Rəng tapılmadı");
            color.DeletedAt = DateTime.UtcNow;
            _repository.Update(color);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(ColorUpdateDTO colorUpdateDTO)
        {
            var color = await _repository.GetByIdAsync(colorUpdateDTO.Id);
            if (color == null) throw new KeyNotFoundException("Rəng tapılmadı");
            var isExist = await _repository.AnyAsync(c => c.Name.Trim().ToLower() == colorUpdateDTO.Name.Trim().ToLower() && c.Id != colorUpdateDTO.Id);
            if (isExist) throw new ValidationException("Name", "Eyni rəng əlavə etmək olmaz!");
            color.Name = colorUpdateDTO.Name;
            color.UpdatedAt = DateTime.UtcNow;
            _repository.Update(color);
            await _repository.SaveAsync();
        }

    }
}
