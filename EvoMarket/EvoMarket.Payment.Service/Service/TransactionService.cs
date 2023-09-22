using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Payment.AccountDto;
using Domain.Dto.Payment.TransactionDto;
using Domain.Entities.Payment;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Payment.Infrastructure.Intercafes;

namespace EvoMarket.Payment.Service.Service;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IClientAccountRepository _clientAccountRepository;
    private readonly DataContext _context;

    public TransactionService(ITransactionRepository transactionRepository,IClientAccountRepository clientAccountRepository, DataContext context)
    {
        _transactionRepository = transactionRepository;
        _clientAccountRepository = clientAccountRepository;
        _context = context;
    }



    public async ValueTask<TransactionsResponseDto> GetByIdAndTime(TransactionsRequestDto transactionsRequestDto)
    {
        var clientAccount =await _clientAccountRepository.GetByIdAsync(transactionsRequestDto.ClientAccountId);
        if (clientAccount is null)
        {
            throw new Exception("Client Account not fount");
        }

        if (transactionsRequestDto.BeginTime > transactionsRequestDto.EndTime)
        {
            throw new Exception("the time range is not specified correctly (TransactionService)");
        }

        var transactions =  _transactionRepository.
            DbGetSet().
            Where(x=>x.AccountId==transactionsRequestDto.ClientAccountId && 
                     x.Time>transactionsRequestDto.BeginTime && 
                     x.Time<transactionsRequestDto.EndTime).
            ToArray();

        var transactionDtos = new TransactionUpdateDto[transactions.Length];
        
        for (int i=0;i<transactions.Length;i++)
        {
            transactionDtos[i]=(new TransactionUpdateDto()
            {
                Amount = transactions[i].Amount,
                Id = transactions[i].Id,
                Success = transactions[i].Success,
                Time = transactions[i].Time
            });
        }


        return new TransactionsResponseDto()
        {
            BeginTime = transactionsRequestDto.BeginTime,
            EndTime = transactionsRequestDto.EndTime,
            ClientAccountId = transactionsRequestDto.ClientAccountId,
            Transactions = transactionDtos
        };
    }


    public async ValueTask<TransactionUpdateDto> Transaction(TransactionCreateDto transactionCreateDto)
    {
        var result = new Transaction()
        {
            Time = DateTime.Now
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
                var transactionResult=await _transactionRepository.CreatAsync(result);
                await _context.Database.CommitTransactionAsync();

                return new TransactionUpdateDto()
                {
                    Amount = transactionResult.Amount,
                    Success = transactionResult.Success,
                    Id = transactionResult.Id,
                    Time = transactionResult.Time
                };
            }
            catch (Exception e)
            {
                await _context.Database.RollbackTransactionAsync();
                var transactionResult=await _transactionRepository.CreatAsync(result);
                return new TransactionUpdateDto()
                {
                    Amount = transactionResult.Amount,
                    Success = transactionResult.Success,
                    Id = transactionResult.Id,
                    Time = transactionResult.Time
                };
            }
            
        }
    }
}