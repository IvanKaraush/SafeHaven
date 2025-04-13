using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeHaven.DAL.Interfaces;
using SafeHaven.DAL.Repositories;

namespace SafeHaven.DAL.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<InsuranceDbContext>(configuration.GetConnectionString("DefaultConnection"));

        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        return services;
    }
}