using Domain.Entities.Shops;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class CategoryFilterRepository : RepositoryBase<CategoryFilter>, ICategoryFilterRepository
{
    public CategoryFilterRepository(ShopDataContext context) : base(context)
    {
    }
}