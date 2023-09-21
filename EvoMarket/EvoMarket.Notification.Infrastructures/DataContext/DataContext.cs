using Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Notification.Infrastructures.DataContext;

public class DataContext : DbContext
{
    public DbSet<ClientNotifications> ClientNotifications { get; set; }

    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DataContext(DbContextOptions dbContextOptions): base(dbContextOptions)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.
            UseLazyLoadingProxies();
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=postgres; username=postgres; password=Ab4466195"
            );
        base.OnConfiguring(optionsBuilder);
        
            }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("evo_market");

        modelBuilder.Entity<ClientNotifications>()
            .HasIndex(x => x.Received);

    }
}