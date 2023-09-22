using Domain.Dto.ShopDto;
using Domain.Entities;
using Domain.Entities.Shops;
using EvoMarket.WebCore;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Shop.Api.Controllers;

public abstract class MyControllerBase<T> : ControllerBase where T : ModelBase
{
    private readonly IRepositoryBase<T> _repositoryBase;

    public MyControllerBase(IRepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    [HttpGet]
    public async ValueTask<ApiResult<IEnumerable<T>>> GetAllAsync()
        => ApiResult<T>.FromIEnumerable(await _repositoryBase.GetAllAsync());

    [HttpGet("getbyid{id:long}")]
    public async ValueTask<ApiResult<T>> GetByIdAsync(long id)
        => await _repositoryBase.GetByIdAsync(id);
    
    [HttpDelete("delete/{id:long}")]
    public async ValueTask<ApiResult<T>> DeleteAsync(long id)
        => await _repositoryBase.DeleteAsync(id);
}