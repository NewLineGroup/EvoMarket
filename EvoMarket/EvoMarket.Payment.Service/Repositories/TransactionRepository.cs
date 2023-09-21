using Domain.Entities.Payment;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Payment.Infrastructure.PaymentRepositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(DataContext context)
        : base(context)
    {
    }
}