using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Payment.Infrastructure.PaymentDbContext;

public class PaymentDataContext :  DbContext
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
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost; Port=5432; Database=EvoMarketData; username=postgres; password=2000;");
        base.OnConfiguring(optionsBuilder);
    }
}