using EvoMarket.Auth.Service.Interfaces;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using EvoMarket.Auth.Service.Repositories;
using EvoMarket.Auth.Service.Services;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.Notification.Infrastructures.Repositories;
using EvoMarket.Notification.Services.Interfaces;
using EvoMarket.Notification.Services.Services;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.Shop.Service.Services;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Repositories;

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
        
        serviceCollection.AddScoped<IHashService, HashService>();
        serviceCollection.AddScoped<ITokenService,TokenService>();
        serviceCollection.AddScoped<IAuthService, AuthService>(); 
        serviceCollection.AddScoped<IDeviceService, DeviceService>(); 
        serviceCollection.AddScoped<IClientRepository, ClientRepository>(); 
        serviceCollection.AddScoped<IClientService, ClientService>(); 
        // serviceCollection.AddScoped<INotificationRepository, NotificationRepository>(); 
        // serviceCollection.AddScoped<INotificationService, NotificationService>(); 
    } 
}