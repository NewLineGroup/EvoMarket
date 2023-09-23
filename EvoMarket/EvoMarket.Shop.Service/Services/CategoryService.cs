using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class CategoryService : ServiceBase<Category>, ICategoryService
{
    public CategoryService(ICategoryRepository repository) : base(repository)
    {
    }

    public async ValueTask<Category> CreatAsync(CategoryCreateDto data)
    {
        Category category = new Category()
        {
            Title = data.Title,
            ImageUrl = data.ImageUrl
        };
        return await base._repositoryBase.CreatAsync(category);
    }

    public async ValueTask<Category> UpdateAsync(CategoryUpdateDto data)
    {
        Category category = new Category()
        {
            Title = data.Title,
            ImageUrl = data.ImageUrl
        };
        return await base._repositoryBase.UpdateAsync(category);
    }
}