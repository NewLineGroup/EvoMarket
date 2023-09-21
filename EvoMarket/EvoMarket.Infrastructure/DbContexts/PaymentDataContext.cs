using System.Reflection;
using Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Infrastructures.DbContexts;

public class PaymentDataContext : DbContext
{
    public PaymentDataContext()
    {
        
    }
    public PaymentDataContext(DbContextOptions<PaymentDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    
    
}