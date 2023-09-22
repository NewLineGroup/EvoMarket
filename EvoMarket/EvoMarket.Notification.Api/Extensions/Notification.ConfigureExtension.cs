
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
    
    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INotificationService, NotificationService>();
        serviceCollection.AddScoped<INotificationRepository, NotificationRepository>();
        serviceCollection.AddSingleton<SmtpClient>(provider =>
        {
            NetworkCredential myCredential = new NetworkCredential("evomarket777@gmail.com", "hcsm ymjx iyhf hgxm");
            var client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = myCredential;
            client.EnableSsl = true;

            return client;
        });
    }
}