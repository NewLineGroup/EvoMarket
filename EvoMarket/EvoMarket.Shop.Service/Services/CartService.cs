using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class CartService : ServiceBase<Cart>, ICartService
{
    public CartService(ICartRepository repository) : base(repository)
    {
    }

    public async ValueTask<Cart> CreatAsync(CartCreateDto data)
    {
        Cart cart = new Cart()
        {
            TotalAmount = data.TotalAmount,
            TotalCount = data.TotalCount,
            ClientId = data.ClientId
        };
        return await base._repositoryBase.CreatAsync(cart);
    }

    public async ValueTask<Cart> UpdateAsync(CartUpdateDto data)
    {
        Cart cart = new Cart()
        {
            TotalAmount = data.TotalAmount,
            TotalCount = data.TotalCount,
            ClientId = data.ClientId,
            TransactionId = data.TransactionId,
            Closed = data.Closed
        };
        return await base._repositoryBase.UpdateAsync(cart);
    }

    public async ValueTask<Cart> GetCartByClientId(long clientId)
    {
        var cart = await _repositoryBase.GetByIdAsync(clientId);
        if (cart is null)
        {
           return await _repositoryBase.CreatAsync(new Cart()
            {
                ClientId = clientId
            });
        }

        return cart;
    }
}