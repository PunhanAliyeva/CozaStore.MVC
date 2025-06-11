using CozaStore.Application.DTOs.TagDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;

namespace CozaStore.Persistence.Services
{
    public class TagService : Service<Tag>, ITagService
    {
        private readonly IRepository<Tag> _repository;

        public TagService(IRepository<Tag> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(TagCreateDTO tagCreateDTO)
        {
            if (string.IsNullOrWhiteSpace(tagCreateDTO.Name))
                throw new ArgumentException("Teq adı boş ola bilməz!");
            if (await _repository.AnyAsync(t => t.Name.Trim().ToLower() == tagCreateDTO.Name.Trim().ToLower() && t.DeletedAt == null))
                throw new ArgumentException("Bu adda teq artıq mövcuddur!");
            Tag tag = new() { Name=tagCreateDTO.Name,CreatedAt=DateTime.UtcNow };
            await _repository.AddAsync(tag);
            await _repository.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new KeyNotFoundException("Teq tapılmadı");
            _repository.Delete(tag);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(TagUpdateDTO tagUpdateDTO)
        {
            var tag = await _repository.GetByIdAsync(tagUpdateDTO.Id);
            if (tag == null) throw new KeyNotFoundException("Teq tapılmadı");
            var isExist = await _repository.AnyAsync(t => t.Name.Trim().ToLower() == tagUpdateDTO.Name.Trim().ToLower() && t.Id != tagUpdateDTO.Id);
            if (isExist) throw new ValidationException("Name","Eyniadlı teq əlavə etmək olmaz!");
            tag.Name = tagUpdateDTO.Name;
            tag.UpdatedAt = DateTime.UtcNow;
            _repository.Update(tag);
            await _repository.SaveAsync();
        }
    }
}
