using CozaStore.Domain.Interfaces.IRepositories;
using CozaStore.Domain.Interfaces.IServices;
using CozaStore.Persistence.Data;
using CozaStore.Persistence.Repositories;
using CozaStore.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CozaStore.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ISliderRepository, SliderRepository>();
			services.AddScoped<ISliderService, SliderService>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IAboutRepository, AboutRepository>();
			services.AddScoped<IAboutService, AboutService>();
			services.AddScoped<IBlogRepository, BlogRepository>();
			services.AddScoped<IBlogService, BlogService>();
			services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
			services.AddScoped<IBlogCategoryService, BlogCategoryService>();
			services.AddScoped<IBlogTagRepository, BlogTagRepository>();
			services.AddScoped<IBlogTagService, BlogTagService>();
			services.AddScoped<ITagRepository, TagRepository>();
			services.AddScoped<ITagService,TagService>();
			services.AddScoped<IColorRepository, ColorRepository>();
			services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductImageService, ProductImageService>();
		}
    }
}
