using Blazored.LocalStorage;
using Diploma.BusinessLogic.AuthenticationHandlers.HashManager;
using Diploma.BusinessLogic.AuthenticationHandlers.JwtManager;
using Diploma.BusinessLogic.Repositories.AuthenticationRepository;
using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.BusinessLogic.Repositories.DeliveryRepository;
using Diploma.BusinessLogic.Repositories.EmailRepository;
using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.BusinessLogic.Repositories.OrderRepository;
using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.BusinessLogic.Repositories.WishlistRepository;
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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IHashManager, HashManager>();

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