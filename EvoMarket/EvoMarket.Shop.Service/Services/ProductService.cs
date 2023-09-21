using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class ProductService : ServiceBase<Product>, IProductService
{
    public ProductService(IProductRepository repository) : base(repository)
    {
    }
}