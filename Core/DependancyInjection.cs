using Microsoft.Extensions.DependencyInjection;


namespace Core
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services;
        }
    }
}
