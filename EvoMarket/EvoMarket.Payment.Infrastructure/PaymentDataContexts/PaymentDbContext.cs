using Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.PaymentDataContext;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
    :base(options)
    {
        
    }

    public DbSet<ClientAccount> ClientAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

}