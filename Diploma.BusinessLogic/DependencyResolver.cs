using Microsoft.Extensions.DependencyInjection;

namespace Diploma.BusinessLogic
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            //Server


            return services;
        }

        public static IServiceCollection AddClientDependencies(this IServiceCollection services)
        {
            //Client

            return services;
        }
    }
}