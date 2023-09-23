using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class FilterParamValueService : ServiceBase<FilterParamValue>,IFilterParamValueService
{
    public FilterParamValueService(IFilterParamValueRepository repository) : base(repository)
    {
    }

    public async ValueTask<FilterParamValue> CreateFilterParamValueAsync(FilterParamValueCreateDto dto)
    {
        FilterParamValue filterParamValue = new FilterParamValue
        {
            FilterParamId = dto.FilterParamId,
            Value = dto.ParamValue
        };
        return await base._repositoryBase.CreatAsync(filterParamValue);
    }
}