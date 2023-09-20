using Domain.Entities.Payment;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Payment.Infrastructure.PaymentDbContext;
using Payment.Infrastructure.Repositories.Interface;

namespace Payment.Infrastructure.Repositories;

public class ClientAccountRepository : RepositoryBase<ClientAccount>, IClientAccountRepository
{
    public ClientAccountRepository(PaymentDataContext context) 
        : base(context)
    {
    }
}