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

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("evo_market");

        modelBuilder.Entity<ClientNotifications>()
            .HasIndex(x => x.Received);

    }
}