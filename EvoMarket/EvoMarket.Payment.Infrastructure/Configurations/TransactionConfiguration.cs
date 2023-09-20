using Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment.Infrastructure.Configurations;

public class TransactionConfiguration :  IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        /*builder
            .HasOne(x=>x.Account)
            .WithMany(x=>x.)*/
    }
}