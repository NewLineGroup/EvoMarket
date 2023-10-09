using Domain.Dto.ShopDto;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace EvoMarket.Shop.Api.Controllers;
[ApiController]
[Route("filterparams")]
public class FilterParamController:MyControllerBase<FilterParam>
{
    private readonly IFilterParamRepository _repository;
    private readonly IFilterParamService _service;

    public FilterParamController(IFilterParamRepository repository,IFilterParamService service) : base(repository)
    {
        _repository = repository;
        _service = service;
    }
    [HttpPost("create")]
    public async ValueTask<ApiResult<FilterParam>> CreateAsync(FilterParamCreateDto data)
    {
        return await _service.CreateFilterParamAsync(data);
    }
}