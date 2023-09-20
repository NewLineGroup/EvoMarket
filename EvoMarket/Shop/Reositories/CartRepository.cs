using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Reositories;

public class CartRepository : RepositoryBase<Cart>, ICartRepository
{
    public CartRepository(DbContext context) : base(context)
    {
    }
}