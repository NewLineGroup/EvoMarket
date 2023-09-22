using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class ProductService : ServiceBase<Product>, IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetByFilters([FromBody] FilterDto filter)
    {
        var filters = filter.ResponsiveFilterDtos;
        var query = _repositoryBase.DbGetSet().AsQueryable();
        foreach (var value in filters)
        {
            query = query.Where(x => x
                .FilterParamValues
                .Any(x => x.FilterParam.ParamName == value.ParamName
                          && x.Value == value.Value));
        }

        if (filter.Min is not null)
            query = query
                .Where(x => x.Price >= filter.Min);
        
        if (filter.Max is not null)
            query = query
                .Where(x => x.Price <= filter.Max);
        

        return await query.ToListAsync();
    }


    public async ValueTask<Product> CreatAsync(ProductCreateDto data)
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