
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Payment.AccountDto;
using Domain.Entities.Payment;
using Domain.Entities.Shops;

using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Service.Service;
using EvoMarket.WebCore;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Payment.Api.Controllers;

[Controller]
public class ClientAccountController : ControllerBase
{
    private readonly IClientAccountRepository _clientAccountRepository;

    public ClientAccountController(IClientAccountRepository clientAccountRepository)
    {
        this._clientAccountRepository = clientAccountRepository;
    }

    [HttpPost("CreatClientAccount")]
    public async Task<ApiResult<ClientAccount>> CreateClient([FromBody] ClientAccountCreateDto client)
    {
        var result = await _clientAccountRepository.CreatAsync(new ClientAccount()
        {
            ClientId = client.ClientId,
            Balance = client.Money,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            IsFreeze = false
        });
        if (result is not null)
        {
            return result;
        }

        return ("Client not Created", 500);
    }
    [HttpGet("GetClientAccount")]
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
    public async Task<ApiResult<decimal>> GetCleintBalance([FromQuery] long id)
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
    public async Task<ApiResult<List<Transaction>>> GetClientTransations([FromQuery] long id)
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

    [HttpDelete("DeleteCLientAccount")]
    public async Task<ApiResult<ClientAccount>> DeleteAccount([FromQuery] long id)
    {
        var client = await _clientAccountRepository.GetByIdAsync(id);
        if (client is Client)
        {
            client.IsFreeze = true;
            await _clientAccountRepository.UpdateAsync(client);
        }

        return ("Client Account Not Found", 404);

    }
}