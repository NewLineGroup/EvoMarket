using Domain.Entities.Payment;
using Domain.Entities.Shops;
using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Service.Service;
using EvoMarket.WebCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Payment.Api.Controllers;

[Controller]
public class ClientAccountController : ControllerBase
{
    private readonly IClientAccountRepository _clientAccountRepository;

    public ClientAccountController(IClientAccountRepository _clientAccountRepository,
        ITransactionService transactionService)
    {
        this._clientAccountRepository = _clientAccountRepository;
    }

    [HttpGet("GetClient")]
    public async Task<ApiResult<ClientAccount>> GetClient([FromQuery] long id)
    {
        var client = await _clientAccountRepository.GetByIdAsync(id);
        if (client is Client)
        {
            return client;
        }

        return ("Client Account not Found", 404);
    }

    [HttpGet("getBalance")]
    public async Task<ApiResult<decimal>> GetCleintBalance(long id)
    {
        var client = await _clientAccountRepository.GetByIdAsync(id);
        if (client.Balance is decimal)
            return client.Balance;
        else
        {
            return ("Client Account Not Found", 404);
        }
    }

    [HttpGet("getClientTransations")]
    public async Task<ApiResult<List<Transaction>>> GetClientTransations(long id)
    {
        var client = await _clientAccountRepository.GetByIdAsync(id);
        if (client is Client)
        {
            if (client.Transactions is not null)
            {
                return client.Transactions.ToList();
            }
            else

            {
                return ("Client history not yet ", 404);
            }
        }

        else
        {
            return ("Client Account Not Found", 404);
        }
    }
}