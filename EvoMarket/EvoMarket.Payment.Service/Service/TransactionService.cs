using Domain.Dto.Payment.TransactionDto;
using Domain.Entities.Payment;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;

namespace EvoMarket.Payment.Service.Service;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IClientAccountRepository _clientAccountRepository;
    private readonly PaymentDataContext _context;

    public TransactionService(ITransactionRepository transactionRepository,IClientAccountRepository clientAccountRepository, PaymentDataContext context)
    {
        _transactionRepository = transactionRepository;
        _clientAccountRepository = clientAccountRepository;
        _context = context;
    }


    public async ValueTask<TransactionUpdateDto> Transaction(TransactionCreateDto transactionCreateDto)
    {
        var result = new Transaction()
        {
            Time = DateTime.Now
        };
        var resultDto = new TransactionUpdateDto()
        {
            Time = result.Time
        };
        await using(var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                if (transactionCreateDto.Money <= 0)
                {
                    result.Success = false;
                    throw new Exception("Money  can be negative");
                }

                var clientAccount = await _clientAccountRepository.GetByIdAsync(transactionCreateDto.ClientId);

                if (clientAccount is null)
                {
                    result.Success = false;
                    throw new Exception("Client Account not fount");
                }

                decimal balance = clientAccount.Balance;
                decimal money = transactionCreateDto.Money*(decimal)1.08;
                if (balance <  money)
                {
                    result.Success = false;
                    result.Account = clientAccount;
                    result.AccountId = clientAccount.Id;

                    throw new Exception("not enough money");

                }

                clientAccount.Balance -= money;
                
                await _clientAccountRepository.UpdateAsync(clientAccount);

                result.AccountId = clientAccount.Id;
                result.Account = clientAccount;
                result.Amount = money;
                result.Success = true;
                await _transactionRepository.CreatAsync(result);
                await _context.Database.CommitTransactionAsync();
                
                return resultDto;
            }
            catch (Exception e)
            {
                await _context.Database.RollbackTransactionAsync();
                resultDto.Success = false;
                resultDto.Amount = result.Amount;
                return resultDto;
            }
            
        }
    }
}