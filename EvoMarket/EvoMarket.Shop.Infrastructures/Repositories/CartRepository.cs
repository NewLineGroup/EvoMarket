using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;

namespace Shop.Repositories;

public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    public CartRepository(DataContext context) : base(context)
    {
    }
}
