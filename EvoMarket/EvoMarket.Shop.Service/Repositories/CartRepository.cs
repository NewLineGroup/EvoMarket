using Domain.Entities.Shops;
using EvoMarket.Infrastructures.DbContexts;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;

namespace Shop.Repositories;

public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    public CartRepository(ShopDataContext context) : base(context)
    {
    }
}
