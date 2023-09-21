using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}