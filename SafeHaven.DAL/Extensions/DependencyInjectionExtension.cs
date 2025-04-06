using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SafeHaven.DAL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<InsuranceDbContext>(configuration.GetConnectionString("DefaultConnection"));

        return services;
    }
}