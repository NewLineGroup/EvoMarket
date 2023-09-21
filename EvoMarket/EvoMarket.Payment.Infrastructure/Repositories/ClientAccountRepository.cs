using Domain.Entities.Payment;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Infrastructure.PaymentDataContext;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.PaymentRepositories;

public class ClientAccountRepository : RepositoryBase<ClientAccount> ,IClientAccountRepository
{
    public ClientAccountRepository(PaymentDbContext context) 
        : base(context)
    {
    }
}