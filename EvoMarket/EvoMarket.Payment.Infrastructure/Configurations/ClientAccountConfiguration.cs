using Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment.Infrastructure.Configurations;

public class ClientAccountConfiguration : IEntityTypeConfiguration<ClientAccount>
{
    public void Configure(EntityTypeBuilder<ClientAccount> builder)
    {
        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.ClientAccounts)
            .HasForeignKey(x => x.ClientId);
    }
}