using Domain.Dto.ShopDto;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface IFilterParamValueService : IServiceBase<FilterParamValue>
{
    public ValueTask<FilterParamValue> CreateFilterParamValueAsync(FilterParamValueCreateDto dto);
}