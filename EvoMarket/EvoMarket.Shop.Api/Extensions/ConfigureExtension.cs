
using EvoMarket.Infrastructures.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Api.Extensions;

public static class ConfigureExtension
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<ShopDataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configurationManager.GetConnectionString("DefaultConnectionString"));
        });
    }
    
    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICartRepository, CartRepository>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<ICategoryFilterRepository, CategoryFilterRepository>();
        serviceCollection.AddScoped<IClientRepository, ClientRepository>();
        serviceCollection.AddScoped<IFilterParamRepository, FilterParamRepository>();
        serviceCollection.AddScoped<IFilterParamValueRepository, FilterParamValueRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        
    }
}