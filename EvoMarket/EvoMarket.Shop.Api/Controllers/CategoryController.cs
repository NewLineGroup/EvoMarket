using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;
[ApiController]
[Route("api-shop/categories")]
public class CategoryController : MyControllerBase<Category>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryService _service;

    public CategoryController(ICategoryRepository repository,ICategoryService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<ApiResult<Category>> CreateAsync(CategoryCreateDto data)
    {
        return await _service.CreatAsync(data);
    }
    [HttpPut("update")]
    public async ValueTask<ApiResult<Category>> UpdateAsync(CategoryUpdateDto data)
    {
        return await _service.UpdateAsync(data);
    }
}