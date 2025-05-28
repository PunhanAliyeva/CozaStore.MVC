using CozaStore.MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CozaStore.MVC.Persistence.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
