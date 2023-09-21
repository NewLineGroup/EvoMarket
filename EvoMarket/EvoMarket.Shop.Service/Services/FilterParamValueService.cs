using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class FilterParamValueService : ServiceBase<FilterParamValue>, IFilterParamValueService
{
    public FilterParamValueService(IFilterParamValueRepository repository) : base(repository)
    {
    }
}