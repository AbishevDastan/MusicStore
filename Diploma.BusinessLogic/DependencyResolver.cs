using Diploma.BusinessLogic.Repositories.ItemRepository;
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

            return services;
        }

        public static IServiceCollection AddClientDependencies(this IServiceCollection services)
        {
            //Client
            services.AddScoped<IItemService, ItemService>();

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7233/") });

            return services;
        }
    }
}