using Domain.Entities.Payment;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Infrastructure.PaymentDataContext;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.PaymentRepositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(PaymentDbContext context)
        : base(context)
    {
    }
}