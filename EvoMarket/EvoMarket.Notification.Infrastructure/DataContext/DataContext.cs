using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Notification.Infrastructure;

public class DataContext : DbContext
{
    public  DbSet<ClientNotification> {}
    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true);
    }

    public DataContext(DbContextOptions dbContextOptions): base(dbContextOptions)
    {
        
    }
    
}