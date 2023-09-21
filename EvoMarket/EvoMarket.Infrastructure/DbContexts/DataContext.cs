using System.Reflection;
using Domain.Entities.Notification;
using Domain.Entities.Shops;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Infrastructure.DbContexts;

public class DataContext : DbContext
{
    public DbSet<ClientNotifications> ClientNotifications { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryFilter> CategoryFilters { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<FilterParam> FilterParams { get; set; }
    public DbSet<FilterParamValue> FilterParamValues { get; set; }
    public DbSet<Product> Products { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.Entity<ClientNotifications>()
            .HasIndex(x => x.Received);

        
        
        base.OnModelCreating(modelBuilder);
    }
    
}