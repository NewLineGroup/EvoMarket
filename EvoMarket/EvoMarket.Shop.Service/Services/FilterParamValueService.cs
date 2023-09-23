using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class FilterParamValueService : ServiceBase<FilterParamValue>,IFilterParamValueService
{
    public FilterParamValueService(IRepositoryBase<FilterParamValue> repositoryBase) : base(repositoryBase)
    {
    }

    public async ValueTask<FilterParamValue> CreateFilterParamValueAsync(FilterParamValueCreateDto dto)
    {
        FilterParamValue filterParamValue = new FilterParamValue
        {
            FilterParamId = dto.FilterParamId,
            Value = dto.ParamValue
        };
        return await _repositoryBase.CreatAsync(filterParamValue);
    }
}