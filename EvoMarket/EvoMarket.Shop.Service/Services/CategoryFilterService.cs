using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class CategoryFilterService : ServiceBase<CategoryFilter>, ICategoryFilterService
{
    public CategoryFilterService(ICategoryFilterRepository repository) : base(repository)
    {
    }
}