using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.BusinessLogic.Services.CategoryService;
using Diploma.BusinessLogic.Services.ItemService;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.BusinessLogic
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            //Server
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddClientDependencies(this IServiceCollection services)
        {
            //Client
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7233/") });

            return services;
        }
    }
}