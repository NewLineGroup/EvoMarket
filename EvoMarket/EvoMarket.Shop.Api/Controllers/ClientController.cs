using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("api-shop/clients")]
public class ClientController:MyControllerBase<Client>
{
    private readonly IClientRepository _repository;
    private readonly IClientService _service;

    public ClientController(IClientRepository repository, IClientService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<ApiResult<Client>> CreateAsync(ClientCreateDto data)
    {
        return await _service.CreatAsync(data);
    }
    [HttpPut("update")]
    public async ValueTask<ApiResult<Client>> UpdateAsync(ClientUpdateDto data)
    {
        return await _service.UpdateAsync(data);
    }
}