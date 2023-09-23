using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class ProductService : ServiceBase<Product>, IProductService
{
    protected readonly IProductRepository _repository;
    protected readonly IClientRepository _clientRepository;
    public ProductService(IProductRepository repository, IClientRepository clientRepository) : base(repository)
    {
        _repository = repository;
        _clientRepository = clientRepository;
    }

    /// <summary>
    /// Product GetByFilters
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
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


    /// <summary>
    /// Create Product !
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Product Update !
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
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
    
    /// <summary>
    /// Check Client Age !
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="clientId"></param>
    /// <returns></returns>
    public async ValueTask<Product> CheckClientAge(long productId, long clientId)
    {
        var product = await this._repository.GetByIdAsync(productId);
        var client =await _clientRepository.GetByIdAsync(clientId);
        if (product.MinAge <= client.Age)
            return product;
        else
            throw new Exception("Age not matched ");

    }
    
    /// <summary>
    /// Product Rating Process !
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    public async ValueTask<Product> GetProductsByRating(long productId, float raiting)
    {
        Product product = await _repository.GetByIdAsync(productId);
        if (product.Rate == 0)
        {
            product.Rate = raiting;
        }
        else
        {
            product.Rate = (product.Rate + raiting) / 2;
        }
        
        return await _repository.UpdateAsync(product);
    }
    
    /// <summary>
    /// Promotion process of products!
    /// </summary>
    /// <returns></returns>
    public async ValueTask<Product> DiscountProducts(long productId, decimal discountPrice)
    {
        Product product = await _repository.GetByIdAsync(productId);

        product.DiscountPrice = discountPrice;
        return await _repository.UpdateAsync(product);
    }

    /// <summary>
    /// Filter by Product Category ! 
    /// </summary>
    /// <returns></returns>
    public async ValueTask<Product> ProductCategoryFilter(long productCategoryId)
    {
        Product product = await _repository.GetByIdAsync(productCategoryId);

        if (product.CategoryId != productCategoryId)
            throw new Exception("Product Not Found");
            
        return product;
        
    }

    /// <summary>
    /// Filter by product parameters !
    /// </summary>
    /// <returns></returns>
    public async ValueTask<Product> ProductFilterParam(string title)
    {
        return null;
    }
    
}