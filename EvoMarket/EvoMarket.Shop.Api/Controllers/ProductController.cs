using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductController:MyControllerBase<Product>
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }
    
    [HttpPost("create")]
    public async ValueTask<Product> CreateAsync(ProductCreateDto data)
    {
        Product product = new Product
        {
            CreatedAt = DateTime.Now,
            Title = data.Title,
            Price = data.Price,
            Quantity = data.Quantity,
            ImageUrl = data.ImageUrl,
            ThumbImageUrl = data.ImageUrl,
            Rate = data.Rate,
            CategoryId = data.CategoryId,
            MinAge = data.MinAge
        };
        return await _repository.CreatAsync(product);
    }
    [HttpPut("update")]
    public async ValueTask<Product> UpdateAsync(ProductUpdateDto data)
    {
        Product product = new Product
        {
            UpdatedAt = DateTime.Now,
            Title = data.Title,
            Price = data.Price,
            Quantity = data.Quantity,
            DiscountPrice = data.DiscountPrice,
            ImageUrl = data.ImageUrl,
            ThumbImageUrl = data.ImageUrl,
            Rate = data.Rate,
            CategoryId = data.CategoryId,
            MinAge = data.MinAge
        };
        return await _repository.UpdateAsync(product);
    }
}