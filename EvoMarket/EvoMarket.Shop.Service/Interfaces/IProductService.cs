using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
namespace EvoMarket.Shop.Service.Interfaces;

public interface IProductService : IServiceBase<Product>
{
    public ValueTask<Product> CreatAsync(ProductCreateDto data);
    public ValueTask<Product> UpdateAsync(ProductUpdateDto data);
    public Task<IEnumerable<Product>> GetByFilters( FilterDto filter);
    public ValueTask<Product> CheckProductQuantity(long productId, int quantity);
}