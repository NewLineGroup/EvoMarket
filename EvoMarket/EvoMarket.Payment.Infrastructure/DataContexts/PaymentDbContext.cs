using System.Reflection;
using Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.PaymentDataContext;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext()
    {
        
    }
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options)
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