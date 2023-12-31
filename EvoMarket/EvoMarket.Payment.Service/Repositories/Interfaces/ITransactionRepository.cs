using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Payment;
using EvoMarket.WebCore.Interfaces;

namespace EvoMarket.Payment.Infrastructure.Intercafes;

public interface ITransactionRepository : IRepositoryBase<Transaction>
{
    ValueTask<IEnumerable<Transaction>> GetTransactionsByTimeAsync(DateTime startTime, DateTime endTime);
}