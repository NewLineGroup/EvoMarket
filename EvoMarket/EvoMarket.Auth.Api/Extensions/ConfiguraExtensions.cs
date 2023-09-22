using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.Auth.Service.Repositories;
using EvoMarket.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Api.Extensions;

public static class ConfiguraExtensions
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection,
        ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<DataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configurationManager.GetConnectionString("DefaultConnectionString"));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IDeviceRepository, DeviceRepository>();
    }
}