using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Domain.Entities.Auth;
using Domain.Entities.Notification;
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


    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.Entity<ClientNotification>()
            .HasIndex(x => x.Received);

        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasColumnName("user_id")
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Id)
            .IsUnique();

        modelBuilder.Entity<Device>()
            .Property(x => x.Id)
            .HasColumnName("device_id")
            .IsRequired();

        modelBuilder.Entity<Device>()
            .Property(x => x.UserId)
            .IsRequired();

        modelBuilder.Entity<Device>()
            .HasKey(x => x.UserId)
            .HasName("user_id");

        modelBuilder.Entity<Device>()
            .HasIndex(x => x.Id)
            .IsUnique();
        
        
        base.OnModelCreating(modelBuilder);
    }
    
}