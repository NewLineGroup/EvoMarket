using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class FilterParamService:ServiceBase<FilterParam>,IFilterParamService
{
    public FilterParamService(IFilterParamRepository repository) : base(repository)
    {
    }

    public async ValueTask<FilterParam> CreateFilterParamAsync(FilterParamCreateDto dto)
    {
        FilterParam filterParam = new FilterParam
        {
            ParamName = dto.ParamName
        };
        return await _repositoryBase.CreatAsync(filterParam);
    }
}