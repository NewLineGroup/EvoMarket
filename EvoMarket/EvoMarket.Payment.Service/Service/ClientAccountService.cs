using System;
using System.Threading.Tasks;
using Domain.Dto.Payment.AccountDto;
using Domain.Dto.Payment.TransactionDto;
using Domain.Entities.Payment;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;

namespace EvoMarket.Payment.Service.Service;

public class ClientAccountService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IClientAccountRepository _clientAccountRepository;
    private readonly DataContext _context;

    public ClientAccountService(ITransactionRepository transactionRepository ,IClientAccountRepository clientAccountRepository,DataContext context)
    {
        _transactionRepository = transactionRepository;
        _clientAccountRepository = clientAccountRepository;
        _context = context;
    }


    public async ValueTask<TransactionUpdateDto> TransferToTheBalance(ClientAccountCreateDto account)
    {
        var result = new Transaction()
        {
            Time = DateTime.Now,
            CreatedAt = DateTime.Now
        };
        await using (var transaction=await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var clientAccount = await _clientAccountRepository.GetByIdAsync(account.ClientAccountId);
                if (clientAccount is null)
                {
                    throw new Exception("Account not fount");
                }

                if (account.Money <= 0)
                {
                    throw new Exception("money is negative");
                }


                clientAccount.Balance += account.Money;

                result.Amount = account.Money;
                result.Account = clientAccount;
                result.AccountId = clientAccount.Id;
                result.Success = true;

                await transaction.CommitAsync();

                var transactionResult = await _transactionRepository.CreatAsync(result);
                
                return new TransactionUpdateDto()
                {
                    Success = transactionResult.Success,
                    Time = transactionResult.Time,
                    Amount = transactionResult.Amount,
                    Id = transactionResult.Id
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result.Success = false;
                await transaction.RollbackAsync();
                var transactionResult = await _transactionRepository.CreatAsync(result);
                
                return new TransactionUpdateDto()
                {
                    Success = transactionResult.Success,
                    Time = transactionResult.Time,
                    Amount = transactionResult.Amount,
                    Id = transactionResult.Id
                };
            }
        }


    }




}