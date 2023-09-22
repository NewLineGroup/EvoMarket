using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Payment;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Payment.Infrastructure.PaymentRepositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{
    private readonly DataContext _context;

    public TransactionRepository(DataContext context)
        : base(context)
    {
        _context = context;
    }


    public async ValueTask<IEnumerable<Transaction>> GetTransactionsByTimeAsync(DateTime startTime , DateTime endTime)
    {
        var data = this._context.Set<Transaction>()
            .Where(t => t.Time >= startTime && t.Time <= endTime);

        return data;
    }
}