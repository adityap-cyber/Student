
using Infrastructure.Data;
using JasperFx.Events.Projections;
using Marten;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            
            services.AddMarten(options =>
            {
                options.Connection(
                    configuration.GetConnectionString("DefaultConnection"));
                options.Projections.Add<StudentProjection>(
                    ProjectionLifecycle.Inline); 
            });
            return services;
        }
    }
}
