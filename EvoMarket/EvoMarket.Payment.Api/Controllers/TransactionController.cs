using System.Threading.Tasks;
using Domain.Dto.Payment.TransactionDto;
using EvoMarket.Payment.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvoMarket.Payment.Api.Controllers;
[Controller , Route("payment/")]
public class TransactionController :ControllerBase
{
    private readonly ITransactionService _transactionService;
    private readonly ILogger<TransactionController> _logger;

    public TransactionController(ITransactionService transactionService , ILogger<TransactionController> logger)
    {
        _transactionService = transactionService;
        _logger = logger;
    }


    [HttpPost]
    public async ValueTask<IActionResult> GetTransaction([FromBody]TransactionCreateDto transactionCreateDto)
    {
        this._logger.LogInformation("Controller GetTransaction is Working");
        if (transactionCreateDto is null)
        {
            return NotFound();
        }

        await  this._transactionService.Transaction(transactionCreateDto);

        return Ok(transactionCreateDto);

    }

}