using Domain.Entities;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class ServiceBase<T> : IServiceBase<T> where T : ModelBase
{
    private readonly RepositoryBase<T> _repositoryBase;

    public ServiceBase(RepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async ValueTask<IEnumerable<T>> GetAll()
        => await _repositoryBase.GetAllAsync();

    public async ValueTask<T> GetById(long id)
        => await _repositoryBase.GetByIdAsync(id);

    public async ValueTask<T> Create(T data)
        => await _repositoryBase.CreatAsync(data);

    public async ValueTask<T> Update(T data)
        => await _repositoryBase.UpdateAsync(data);

    public async ValueTask<T> Delete(T data)
        => await _repositoryBase.DeleteAsync(data);

    public async ValueTask<T> Delete(long id)
        => await _repositoryBase.DeleteAsync(id);
}