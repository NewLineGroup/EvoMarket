using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class FilterParamRepository : RepositoryBase<FilterParam>, IFilterParamRepository
{
    public FilterParamRepository(DataContext context) : base(context)
    {
    }
}