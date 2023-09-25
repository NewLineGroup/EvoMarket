using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;
[ApiController]
[Route("api-shop/filterparamvalues")]
public class FilterParamValueController:MyControllerBase<FilterParamValue>
{
    private readonly IFilterParamValueRepository _repository;
    private readonly IFilterParamValueService _service;

    public FilterParamValueController(IFilterParamValueRepository repository,IFilterParamValueService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }
    
    [HttpPost("create")]
    public async ValueTask<ApiResult<FilterParamValue>> CreateAsync(FilterParamValueCreateDto data)
    {
        return await _service.CreateFilterParamValueAsync(data);
    }
}