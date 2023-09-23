using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class CartItemService:ServiceBase<CartItem>,ICartItemService
{
    private readonly ICartService _cartService;
    private readonly IProductService _service;

    public CartItemService(ICartItemRepository repository, ICartService cartService,
       IProductService service) : base(repository)
    {
        _cartService = cartService;
        _service = service;
    }

    public async ValueTask<CartItem> AddProductToCart(long productId, int quantity,long clientId)
    {
   
        Product product = await _service.CheckProductQuantity(productId, quantity);
        if (product is null)
        {
            throw new Exception("Not found product");
        }
        Cart cart =  await _cartService.GetCartByClientId(clientId);
        if (cart is null)
        {
            cart = await _cartService.CreatAsync(new CartCreateDto
            {
                TotalCount = quantity,
                ClientId = clientId
            });
        }
        
        var cartItem =await _repositoryBase.CreatAsync(new CartItem
        {
            ProductId = productId,
            CartId = cart.Id,
            Quantity = quantity
        });
        return cartItem;
    }


    public async ValueTask<CartItem> CreatAsync(CartItemCreateDto data)
    {
        CartItem cartItem = new CartItem
        {
            ProductId = data.ProductId,
            CartId = data.CartId,
            Quantity = data.Quantity
        };
        
        return await base._repositoryBase.CreatAsync(cartItem);
    }

    public async ValueTask<CartItem> UpdateAsync(CartItemUpdateDto data)
    {
        CartItem cartItem = new CartItem
        {
            ProductId = data.ProductId,
            CartId = data.CartId,
            Quantity = data.Quantity
        };
        
        return await base._repositoryBase.UpdateAsync(cartItem);
    }
}