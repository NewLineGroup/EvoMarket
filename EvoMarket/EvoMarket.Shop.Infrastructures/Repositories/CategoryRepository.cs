using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class CategoryRepository : RepositoryBase<Category> , ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
        
    }
}