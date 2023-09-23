using Domain.Dto.ShopDto;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface IProductService : IServiceBase<Product>
{
    public ValueTask<Product> CreatAsync(ProductCreateDto data);
    public ValueTask<Product> UpdateAsync(ProductUpdateDto data);
}