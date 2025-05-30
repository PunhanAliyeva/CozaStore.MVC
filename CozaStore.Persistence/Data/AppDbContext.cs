using CozaStore.MVC.Entities;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutContent> AboutContents { get; set; }
    }
}
