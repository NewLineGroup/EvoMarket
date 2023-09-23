using Domain.Entities;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class ServiceBase<T> : IServiceBase<T> where T : ModelBase
{
    protected readonly IRepositoryBase<T> _repositoryBase;

    public ServiceBase(IRepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
}