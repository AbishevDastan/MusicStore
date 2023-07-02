using Blazored.LocalStorage;
using Diploma.BusinessLogic.Repositories.AuthenticationRepository;
using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.BusinessLogic.Repositories.ItemRepository;
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
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            return services;
        }

        public static IServiceCollection AddClientDependencies(this IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7233/") });
            services.AddBlazoredLocalStorage();

            return services;
        }
    }
}