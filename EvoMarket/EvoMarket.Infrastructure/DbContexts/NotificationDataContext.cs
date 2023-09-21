using Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Infrastructures.DbContexts;

public class NotificationDataContext : DbContext
{
    public DbSet<ClientNotifications> ClientNotifications { get; set; }

    public NotificationDataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public NotificationDataContext(DbContextOptions dbContextOptions): base(dbContextOptions)
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