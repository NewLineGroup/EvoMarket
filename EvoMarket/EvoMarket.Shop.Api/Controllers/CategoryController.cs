using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;
[ApiController]
[Route("categories")]
public class CategoryController : MyControllerBase<Category>
{
    private readonly ICategoryRepository _repository;
    public CategoryController(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpPost("create")]
    public async ValueTask<Category> CreateAsync(CategoryCreateDto data)
    {
        Category category = new Category
        {
            CreatedAt = DateTime.Now,
            Title = data.Title,
            ImageUrl = data.ImageUrl,
        };
        return await _repository.CreatAsync(category);
    }
    [HttpPut("update")]
    public async ValueTask<Category> UpdateAsync(CategoryUpdateDto data)
    {
        Category category = new Category
        {
            UpdatedAt = DateTime.Now,
            Title = data.Title,
            ImageUrl = data.ImageUrl,
        };
        return await _repository.UpdateAsync(category);
    }
}