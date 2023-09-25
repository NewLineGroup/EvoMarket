using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;
[ApiController]
[Route("api-shop/categoryfilters")]
public class CategoryFilterController:MyControllerBase<CategoryFilter>
{
    private readonly ICategoryFilterRepository _repository;
    private readonly ICategoryFilterService _service;

    public CategoryFilterController(ICategoryFilterRepository repository,
        ICategoryFilterService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<ApiResult<CategoryFilter>> CreateAsync(CategoryFilterCreateDto data)
    {
        return await _service.CreateCategoryFilterAsync(data);
    }
}