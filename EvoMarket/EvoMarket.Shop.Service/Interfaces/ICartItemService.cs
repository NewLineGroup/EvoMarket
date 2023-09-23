using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;

namespace EvoMarket.Shop.Service.Interfaces;

public interface ICartItemService:IServiceBase<CartItem>
{
    public ValueTask<CartItem> CreatAsync(CartItemCreateDto data);
    public ValueTask<CartItem> UpdateAsync(CartItemUpdateDto data);
}