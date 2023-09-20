using Domain.Entities.Payment;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Payment.Infrastructure.Repositories.Interface;

namespace Payment.Infrastructure.Repositories;

public class TransactionRepository : RepositoryBase<Transaction>,ITransactionRepository
{
    public TransactionRepository(DbContext context)
        : base(context)
    {
    }
}