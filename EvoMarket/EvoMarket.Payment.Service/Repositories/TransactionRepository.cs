using Domain.Entities.Payment;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Payment.Infrastructure.PaymentRepositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(PaymentDataContext context)
        : base(context)
    {
    }
}