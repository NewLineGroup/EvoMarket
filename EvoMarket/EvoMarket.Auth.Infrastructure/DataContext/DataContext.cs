using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Infrastructure.DataContext;

public class DataContext : DbContext
{
    [Column("devies")]
    public DbSet<Device> Devices { get; set; }
    [Column("users")]
    public DbSet<User> Users { get; set; }

    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("evoMarket_auth_infrastructure");

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
    }
}