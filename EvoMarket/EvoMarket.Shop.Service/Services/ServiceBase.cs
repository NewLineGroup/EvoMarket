using Domain.Entities;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class ServiceBase<T> : IServiceBase<T> where T : ModelBase
{
    private readonly IRepositoryBase<T> _repositoryBase;

    public ServiceBase(IRepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async ValueTask<IEnumerable<T>> GetAllAsync()
        => await _repositoryBase.GetAllAsync();

    public async ValueTask<T> GetByIdAsync(long id)
        => await _repositoryBase.GetByIdAsync(id);

    public async ValueTask<T> CreateAsync(T data)
        => await _repositoryBase.CreatAsync(data);

    public async ValueTask<T> UpdateAsync(T data)
        => await _repositoryBase.UpdateAsync(data);

    public async ValueTask<T> DeleteAsync(T data)
        => await _repositoryBase.DeleteAsync(data);

    public async ValueTask<T> DeleteAsync(long id)
        => await _repositoryBase.DeleteAsync(id);
}