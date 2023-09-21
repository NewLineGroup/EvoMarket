using Domain.Entities.Payment;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Infrastructure.PaymentDataContext;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Service.Service;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IClientAccountRepository _clientAccountRepository;
    private readonly PaymentDbContext _context;

    public TransactionService(ITransactionRepository transactionRepository,IClientAccountRepository clientAccountRepository,PaymentDbContext context)
    {
        _transactionRepository = transactionRepository;
        _clientAccountRepository = clientAccountRepository;
        _context = context;
    }


    public async ValueTask<Transaction> Transaction(long clientId, decimal money, decimal foiz)
    {
        var result = new Transaction()
        {
            Time = DateTime.Now
        };
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {

                
                if (money <= 0 || foiz < 0)
                {
                    result.Success = false;
                    throw new Exception("Money or foiz can be negative");
                }

                var clientAccount = await _clientAccountRepository.GetByIdAsync(clientId);

                if (clientAccount is null)
                {
                    result.Success = false;
                    throw new Exception("Client Account not fount");
                }

                decimal balance = clientAccount.Balance;

                if (balance < money * foiz)
                {
                    result.Success = false;
                    result.Account = clientAccount;
                    result.AccountId = clientAccount.Id;

                    throw new Exception("not enough money");

                }

                clientAccount.Balance -= money * foiz;

                await _clientAccountRepository.UpdateAsync(clientAccount);

                result.AccountId = clientAccount.Id;
                result.Account = clientAccount;
                result.Amount = money * foiz;
                result.Success = true;

                await _transactionRepository.UpdateAsync(result);

                await _context.Database.CommitTransactionAsync();

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await _context.Database.RollbackTransactionAsync();
                return result;
            }
            
        }
    }
}