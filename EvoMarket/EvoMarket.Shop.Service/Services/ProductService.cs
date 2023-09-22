using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class ProductService : ServiceBase<Product>, IProductService
{
    public ProductService(IProductRepository repository) : base(repository)
    {
    }
}