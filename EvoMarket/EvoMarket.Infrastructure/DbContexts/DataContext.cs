using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Domain.Entities.Auth;
using Domain.Entities.Notification;
using Domain.Entities.Payment;
using Domain.Entities.Shops;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Infrastructure.DbContexts;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Device> UserDevices { get; set; }
    public DbSet<ClientNotification> ClientNotifications { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryFilter> CategoryFilters { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<FilterParam> FilterParams { get; set; }
    public DbSet<FilterParamValue> FilterParamValues { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ClientAccount> ClientAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configure the database provider here
            optionsBuilder.UseNpgsql(
                "Host=213.230.65.55; Port=5444; Database=shop; username=postgres; password=159357Dax;");
        }
    }
}