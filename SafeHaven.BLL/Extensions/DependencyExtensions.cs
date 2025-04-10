using Microsoft.Extensions.DependencyInjection;
using SafeHaven.BLL.Interfaces;
using SafeHaven.BLL.Mapping;
using SafeHaven.BLL.Services;
using SafeHaven.DAL.Interfaces;
using SafeHaven.DAL.Repositories;

namespace SafeHaven.BLL.Extensions
{
    /// <summary>
    /// Класс-расширение для регистрации зависимостей сервисного слоя и маппинга.
    /// </summary>
    public static class DependencyExtensions
    {
        /// <summary>
        /// Регистрирует все необходимые сервисы, репозитории и AutoMapper.
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI контейнера.</param>
        /// <returns>Коллекция сервисов с добавленными зависимостями.</returns>
        public static IServiceCollection RegisterBll(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IContractRepository, ContractRepository>();

            services.AddScoped<IContractService, ContractService>();

            return services;
        }
    }
}