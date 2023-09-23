using Domain.Dto.ShopDto;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface ICategoryService : IServiceBase<Category>
{
    public ValueTask<Category> CreatAsync(CategoryCreateDto data);
    public ValueTask<Category> UpdateAsync(CategoryUpdateDto data);
}