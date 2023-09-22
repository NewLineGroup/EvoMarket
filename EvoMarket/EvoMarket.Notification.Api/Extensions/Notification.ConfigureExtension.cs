
using System.Net;
using System.Net.Mail;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.Notification.Infrastructures.Repositories;
using EvoMarket.Notification.Services.Interfaces;
using EvoMarket.Notification.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Shop.Api.Extensions;

public static class NotificationConfigureExtension
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<DataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configurationManager.GetConnectionString("DefaultConnectionString"));
        });
    }
    
    public static void ConfigureRepositories(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddScoped<INotificationService, NotificationService>();
        serviceCollection.AddScoped<INotificationRepository, NotificationRepository>();
        serviceCollection.AddSingleton<SmtpClient>(provider =>
        {
            var username = configurationManager.GetSection("SMTP:Username").Get<string>();
            var password = configurationManager.GetSection("SMTP:Password").Get<string>();
            var host = configurationManager.GetSection("SMTP:Host").Get<string>();
            var port = configurationManager.GetSection("SMTP:Port").Get<int>();
            NetworkCredential myCredential = new NetworkCredential(username, password );
            var client = new SmtpClient();
            client.Host = host;
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = myCredential;
            client.EnableSsl = true;

            return client;
        });
    }
}