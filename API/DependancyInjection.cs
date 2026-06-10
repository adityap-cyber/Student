using Application;
using Infrastructure;
namespace API
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration).AddApplication();
            return services;
        }
    }
}
