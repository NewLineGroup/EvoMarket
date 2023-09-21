using Domain.Entities.Shops;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class FilterParamRepository : RepositoryBase<FilterParam>, IFilterParamRepository
{
    public FilterParamRepository(ShopDataContext context) : base(context)
    {
    }
}