using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Payment.TransactionDto;
using Domain.Entities.Payment;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Service.Service;
using EvoMarket.WebCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvoMarket.Payment.Api.Controllers;
[Controller , Route("payment/")]
public class TransactionController :ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILogger<TransactionController> _logger;

    public TransactionController(ITransactionService transactionService ,
        ITransactionRepository transactionRepository ,
        ILogger<TransactionController> logger)
    {
        _transactionService = transactionService;
        _transactionRepository = transactionRepository;
        _logger = logger;
    }


    [HttpPost]
    public async ValueTask<ApiResult<Transaction>> CreateTransaction([FromBody]TransactionCreateDto transactionCreateDto)
    {
        this._logger.LogInformation("TransactionController in CreateTransaction method is Working");
        if (transactionCreateDto is null)
        {
            return ("NotFound",404);
        }

        var client = new Transaction()
        {
            Amount = transactionCreateDto.Money,
            AccountId = transactionCreateDto.ClientId,
            Time = DateTime.Now
        };
        
        await  this._transactionService.Transaction(transactionCreateDto);
        return client;
    }

    [HttpGet("search/time/")]
    public async ValueTask<ApiResult<IEnumerable<Transaction>>> GetTransactionsByTime(TransactionGetByTimeDto transactionGetByTimeDto)
    {
        this._logger.LogInformation("TransactionController in GetTransactionsByTime method is Working");
        
       var result =  await this._transactionRepository
           .GetTransactionsByTimeAsync(transactionGetByTimeDto.StartTime,
            transactionGetByTimeDto.EndTime);
       return result.ToList();
    }
}