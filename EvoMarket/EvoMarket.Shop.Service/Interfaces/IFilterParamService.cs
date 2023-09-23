using Domain.Dto.ShopDto;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface IFilterParamService : IServiceBase<FilterParam>
{
    public ValueTask<FilterParam> CreateFilterParamAsync(FilterParamCreateDto dto);
}