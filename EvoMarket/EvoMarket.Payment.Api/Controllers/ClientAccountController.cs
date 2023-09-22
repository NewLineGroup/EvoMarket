using EvoMarket.Payment.Infrastructure.Intercafes;
using EvoMarket.Payment.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Payment.Api.Controllers;
[Controller]
public class ClientAccountController : ControllerBase
{
    private readonly IClientAccountService _clientAccountService;
    private readonly IClientAccountRepository _clientAccountRepository;

    public ClientAccountController(IClientAccountService clientAccountService ,IClientAccountRepository clientAccountRepository )
    {
        _clientAccountService = clientAccountService;
        _clientAccountRepository = clientAccountRepository;
    }
    
    
    
}