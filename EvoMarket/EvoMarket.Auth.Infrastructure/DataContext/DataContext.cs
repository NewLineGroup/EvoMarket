using Domain.Entities.Shops;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Infrastructure.DataContext;

public class DataContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryFilter> CategoryFilters { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<FilterParam> FilterParams { get; set; }
    public DbSet<FilterParamValue> FilterParamValues { get; set; }
    public DbSet<Product> Products { get; set; }

    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
        optionsBuilder.UseNpgsql(
            "Host=localhost; Port=5432; Database=ForDataContext; username=postgres; password=Xontaxta*2");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("evoMarket_auth_infrastructure");
    }
}