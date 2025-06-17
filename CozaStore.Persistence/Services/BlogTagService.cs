using CozaStore.Application.DTOs.BlogTagDTOs;
using CozaStore.Application.Exceptions;
using CozaStore.Domain.Entities;
using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;

namespace CozaStore.Persistence.Services
{
    public class BlogTagService : Service<BlogTag>, IBlogTagService
	{
		private readonly IRepository<BlogTag> _repository;

		public BlogTagService(IRepository<BlogTag> repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task CreateAsync(BlogTagCreateDTO blogTagCreateDTO)
		{
			if (string.IsNullOrWhiteSpace(blogTagCreateDTO.Name))
				throw new ArgumentException("Bloq-teq adı boş ola bilməz!");
			if (await _repository.AnyAsync(bt => bt.Name.Trim().ToLower() == blogTagCreateDTO.Name.Trim().ToLower() && bt.DeletedAt==null))
				throw new ValidationException("Name","Bu adda bloq-teq artıq mövcuddur!");
			BlogTag blogTag = new() { Name = blogTagCreateDTO.Name, CreatedAt = DateTime.UtcNow };
			await _repository.AddAsync(blogTag);
			await _repository.SaveAsync();
		}
        public async Task DeleteAsync(int id)
        {
            var blogTag = await _repository.GetAsync(b => b.Id == id);
            if (blogTag == null) throw new KeyNotFoundException("Bloq-Teq tapılmadı");
            _repository.Delete(blogTag);
            await _repository.SaveAsync();
        }
        public async Task UpdateAsync(BlogTagUpdateDTO blogTagUpdateDTO)
        {
            var blogTag = await _repository.GetAsync(b=>b.Id==blogTagUpdateDTO.Id);
            if (blogTag == null) throw new KeyNotFoundException("Bloq-Teq tapılmadı");
            var isExist = await _repository.AnyAsync(bt => bt.Name.Trim().ToLower() == blogTagUpdateDTO.Name.Trim().ToLower() && bt.Id != blogTagUpdateDTO.Id);
            if (isExist) throw new ValidationException("Name", "Eyniadlı bloq-teq əlavə etmək olmaz!");
            blogTag.Name = blogTagUpdateDTO.Name;
            blogTag.UpdatedAt = DateTime.UtcNow;
            _repository.Update(blogTag);
            await _repository.SaveAsync();
        }

    }
}
