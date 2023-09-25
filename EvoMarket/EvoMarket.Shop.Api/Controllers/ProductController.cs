using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;

[ApiController]
[Route("api-shop/products")]
public class ProductController:MyControllerBase<Product>
{
    private readonly IProductRepository _repository;
    private readonly IProductService _service;

    public ProductController(IProductRepository repository, IProductService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<ApiResult<Product>> CreateAsync(ProductCreateDto data)
    {
        return await _service.CreatAsync(data);
    }
    [HttpPut("update")]
    public async ValueTask<ApiResult<Product>> UpdateAsync(ProductUpdateDto data)
    {
        return await _service.UpdateAsync(data);
    }

    [HttpGet(nameof(GetByFilters))]
    public async Task<IEnumerable<Product>> GetByFilters([FromBody] FilterDto filter)
    {
        return await _service.GetByFilters(filter);
    }
}