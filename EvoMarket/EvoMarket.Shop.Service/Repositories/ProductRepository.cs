using Domain.Entities.Shops;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    public ProductRepository(ShopDataContext context) : base(context)
    {
    }
}