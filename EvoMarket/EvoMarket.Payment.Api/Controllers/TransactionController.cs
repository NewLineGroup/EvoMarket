using EvoMarket.Payment.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Payment.Api.Controllers;
[Controller]
public class TransactionController :ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    
    
    
}