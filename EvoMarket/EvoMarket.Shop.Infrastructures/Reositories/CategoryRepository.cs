using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Reositories;

public class CategoryRepository : RepositoryBase<Category> , ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
        
    }
}