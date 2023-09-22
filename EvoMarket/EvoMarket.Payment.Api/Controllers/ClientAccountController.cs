using EvoMarket.Payment.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Payment.Api.Controllers;
[Controller]
public class ClientAccountController : ControllerBase
{
    private readonly IClientAccountService _clientAccountService;

    public ClientAccountController(IClientAccountService clientAccountService)
    {
        _clientAccountService = clientAccountService;
    }
    
    
    
}