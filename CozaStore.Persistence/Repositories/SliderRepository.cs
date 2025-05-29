using CozaStore.MVC.Domain.Interfaces.IRepositories;
using CozaStore.MVC.Models.Entities;
using CozaStore.MVC.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Repositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly AppDbContext _context;

        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await _context.Sliders.Where(s => s.DeletedAt == null).ToListAsync();
        }
        public async Task<Slider?> GetByIdAsync(int id)
        {
            return await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null);
        }

        public async Task AddAsync(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
        }

        public void Update(Slider slider)
        {
            _context.Sliders.Update(slider);
        }

        public void Delete(Slider slider)
        {
            slider.DeletedAt = DateTime.UtcNow;
            _context.Sliders.Update(slider);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
