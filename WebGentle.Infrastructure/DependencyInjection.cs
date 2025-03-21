using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebGentle.Domain.Interfaces;
using WebGentle.Infrastructure.Data;
using WebGentle.Infrastructure.Repositories;

namespace WebGentle.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");
                }
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));

            return services;
        }
    }
}
