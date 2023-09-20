using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.PaymentDbContexts;

public class PaymentDataContext : DbContext
{
    public PaymentDataContext()
    {
        
    }
    public PaymentDataContext(DbContextOptions<PaymentDataContext> options)
    :base(options)
    {
        
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=EvoMarket; username=postgres; password=2000;");
        base.OnConfiguring(optionsBuilder);
    }
}