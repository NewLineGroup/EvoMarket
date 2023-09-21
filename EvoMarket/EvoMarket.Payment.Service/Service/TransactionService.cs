using Domain.Entities.Payment;
using EvoMarket.Payment.Infrastructure.Intercafes;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Service.Service;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IClientAccountRepository _clientAccountRepository;

    public TransactionService(ITransactionRepository transactionRepository,IClientAccountRepository clientAccountRepository)
    {
        _transactionRepository = transactionRepository;
        _clientAccountRepository = clientAccountRepository;
    }


    public async ValueTask<Transaction> Transaction(long clientId, decimal Money,decimal foiz)
    {
        if (Money <= 0 || foiz < 0)
        {
            throw new Exception("Money or foiz can be negative");
            return null;
        }

        var clientAccount = await _clientAccountRepository.GetByIdAsync(clientId);

        if (clientAccount is null)
        {
            throw new Exception("Client Account not fount");
            return null;
        }

        decimal balance = clientAccount.Balance;

        if (balance < Money * foiz)
        {
            return await _transactionRepository.CreatAsync(new Transaction()
            {
                Account = clientAccount,
                AccountId = clientAccount.Id,
                Time = DateTime.Now,
                Amount = Money * foiz,
                Success = false
            });
        }

        clientAccount.Balance -= Money * foiz;

        await _clientAccountRepository.UpdateAsync(clientAccount);
        var transaction = await _transactionRepository.CreatAsync(new Transaction()
        {
            Amount = Money * foiz,
            Account = clientAccount,
            AccountId = clientAccount.Id,
            Time = DateTime.Now,
            Success = true
        });


        return transaction;
    } 
}