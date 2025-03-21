using System.Runtime.CompilerServices;
using WebGentle.Application

using WebGentle.Infrastructure;

namespace WebGentle.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI();
            return services;
        }
    }
}
