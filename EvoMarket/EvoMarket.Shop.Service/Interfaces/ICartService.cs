using Domain.Dto.ShopDto;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface ICartService : IServiceBase<Cart>
{
    public ValueTask<Cart> CreatAsync(CartCreateDto data);
    public ValueTask<Cart> UpdateAsync(CartUpdateDto data);
}