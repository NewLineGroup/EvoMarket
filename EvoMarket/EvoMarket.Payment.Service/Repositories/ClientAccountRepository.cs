using Domain.Entities.Payment;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Payment.Infrastructure.PaymentRepositories;

public class ClientAccountRepository : RepositoryBase<ClientAccount> ,IClientAccountRepository
{
    public ClientAccountRepository(DataContext context) 
        : base(context)
    {
    }
}