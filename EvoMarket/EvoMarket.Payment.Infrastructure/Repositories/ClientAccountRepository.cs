using Domain.Payment.Models;
using EvoMarket.Payment.Infrastructure.PaymentDbContexts;
using EvoMarket.Payment.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.Repositories;

public class ClientAccountRepository : RepositoryBase<ClientAccount> , IClientAccountRepository
{
    public ClientAccountRepository(PaymentDataContext context) 
        : base(context)
    {
    }
}