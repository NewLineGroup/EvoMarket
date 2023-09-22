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
    public ProductService(IProductRepository repository) : base(repository)
    {
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
    
    
}