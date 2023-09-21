using Domain.Entities.Shops;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class FilterParamValueRepository : RepositoryBase<FilterParamValue>, IFilterParamValueRepository
{
    public FilterParamValueRepository(ShopDataContext context) : base(context)
    {
    }
}