using Domain.Entities.Shops;
using Microsoft.EntityFrameworkCore;

namespace Notification.DataContext;

public class DataContext : DbContext
{
    public DbSet<ClientNotification> ClientNotifications { get; set; }

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
        optionsBuilder.UseNpgsql();
        base.OnConfiguring(optionsBuilder);
        
       }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("evo_market");

        modelBuilder.Entity<ClientNotification>()
            .HasIndex(x => x.Received);
    }
}