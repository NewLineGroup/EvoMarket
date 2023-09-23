using Domain.Dto.ShopDto;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface ICategoryFilterService : IServiceBase<ICategoryFilterService>
{
    public ValueTask<CategoryFilter> CreateCategoryFilterAsync(CategoryFilterCreateDto createDto);
}