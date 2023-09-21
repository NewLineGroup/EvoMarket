using Domain.Entities.Shops;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class FilterParamValueRepository : RepositoryBase<FilterParamValue>, IFilterParamValueRepository
{
    public FilterParamValueRepository(DataContext context) : base(context)
    {
    }
}