using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;

namespace Shop.Repositories;

public class CartItemRepository:RepositoryBase<CartItem>,ICartItemRepository
{
    public CartItemRepository(DataContext context) : base(context)
    {
    }
}