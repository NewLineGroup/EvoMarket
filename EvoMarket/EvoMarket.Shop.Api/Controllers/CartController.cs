using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("carts")]
public class CartController : MyControllerBase<Cart>
{
    private readonly ICartRepository _repository;
    private readonly ICartService _service;

    public CartController(ICartRepository repository,ICartService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<ApiResult<Cart>> CreateAsync(CartCreateDto data)
    {
        
        return await _service.CreatAsync(data);
    }
    [HttpPut("update")]
    public async ValueTask<ApiResult<Cart>> UpdateAsync(CartUpdateDto data)
    {
        return await _service.UpdateAsync(data);
    }
}