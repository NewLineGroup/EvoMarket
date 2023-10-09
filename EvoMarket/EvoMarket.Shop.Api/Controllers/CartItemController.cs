using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("cartItems")]
public class CartItemController:MyControllerBase<CartItem>
{
    private readonly ICartItemService _service;

    public CartItemController(ICartItemRepository repository,ICartItemService service) : base(repository)
    {
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<ApiResult<CartItem>> CreateAsync(CartItemCreateDto data)
    {
        return await _service.CreatAsync(data);
    }
    
    [HttpPut("update")]
    public async ValueTask<ApiResult<CartItem>> UpdateAsync(CartItemUpdateDto data)
    {
        return await _service.UpdateAsync(data);
    }
}