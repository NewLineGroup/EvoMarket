using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.Shop.Service.Services;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Api.Extensions;

public static class ConfigureExtension
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
        // repositories
        serviceCollection.AddScoped<ICartRepository, CartRepository>();
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<ICategoryFilterRepository, CategoryFilterRepository>();
        serviceCollection.AddScoped<IClientRepository, ClientRepository>();
        serviceCollection.AddScoped<IFilterParamRepository, FilterParamRepository>();
        serviceCollection.AddScoped<IFilterParamValueRepository, FilterParamValueRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        
        //services
        serviceCollection.AddScoped<ICartService, CartService>();
        serviceCollection.AddScoped<ICategoryFilterService, CategoryFilterService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<IClientService, ClientService>();
        serviceCollection.AddScoped<IFilterParamService, FilterParamService>();
        serviceCollection.AddScoped<IFilterParamValueService, FilterParamValueService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
    }
}