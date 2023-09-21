using Domain.Entities.Payment;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Infrastructure.PaymentDataContext;
using EvoMarket.Payment.Infrastructure.PaymentRepositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Api.Extensions;

public static class ConfigureExtensions
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection, ConfigurationManager manager)
    {
        serviceCollection.AddDbContext<PaymentDbContext>(options =>
        {
            options
                .UseNpgsql(manager.GetConnectionString("DefaultConnectionString"));
        });
    }
    
    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
        serviceCollection.AddScoped<IClientAccountRepository, ClientAccountRepository>();
        
    }
}