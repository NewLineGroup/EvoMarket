using System.Runtime.CompilerServices;
using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class CategoryFilterService : ServiceBase<CategoryFilter>, ICategoryFilterService
{
    public CategoryFilterService(ICategoryFilterRepository repository) : base(repository)
    {
    }

    public async ValueTask<CategoryFilter> CreateCategoryFilterAsync(CategoryFilterDto dto)
    {
        CategoryFilter categoryFilter = new CategoryFilter
        {
            CategoryId = dto.CategoryId,
            FilterPramId = dto.FilterParamId,
            Value = dto.CategoryName
        };
        return await _repositoryBase.CreatAsync(categoryFilter);
    }
}