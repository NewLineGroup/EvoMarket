using Domain.Dto.ShopDto;
using Domain.Entities;
using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Shop.Api.Controllers;

public abstract class MyControllerBase<T> : ControllerBase where T : ModelBase
{
    private readonly IRepositoryBase<T> _repositoryBase;

    public MyControllerBase(IRepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    [HttpGet]
    public async ValueTask<IEnumerable<T>> GetAllAsync()
        => await _repositoryBase.GetAllAsync();

    [HttpGet("get_by_id{id:long}")]
    public async ValueTask<T> GetByIdAsync(long id)
        => await _repositoryBase.GetByIdAsync(id);
    
    [HttpDelete("delete/{id:long}")]
    public async ValueTask<T> DeleteAsync(long id)
        => await _repositoryBase.DeleteAsync(id);
}