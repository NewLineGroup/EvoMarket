using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("carts")]
public class CartController : MyControllerBase<Cart>
{
    private readonly ICartRepository _repository;
    public CartController(ICartRepository repository) : base(repository)
    {
        _repository = repository;
    }
    
    [HttpPost("create")]
    public async ValueTask<Cart> CreateAsync(CartCreateDto data)
    {
        Cart cart = new Cart
        {
            CreatedAt = DateTime.Now,
            TotalAmount = data.TotalAmount,
            TotalCount = data.TotalCount,
            ClientId = data.ClientId,
            Closed = false
        };
        return await _repository.CreatAsync(cart);
    }
    [HttpPut("update")]
    public async ValueTask<Cart> UpdateAsync(CartUpdateDto data)
    {
        Cart cart = new Cart()
        {
            UpdatedAt = DateTime.Now,
            TotalAmount = data.TotalAmount,
            TotalCount = data.TotalCount,
            ClientId = data.ClientId,
            TransactionId = data.TransactionId,
            Closed = data.Closed
        };
        return await _repository.UpdateAsync(cart);
    }
}