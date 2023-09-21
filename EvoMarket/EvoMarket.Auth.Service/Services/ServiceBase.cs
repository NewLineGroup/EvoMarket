using Domain.Entities;
using Domain.Entities.Auth;
using EvoMarket.Auth.Infrastructure.Repositories;
using EvoMarket.Auth.Service.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Service.Services;

public class ServiceBase<T> : IServiceBase<T> where T : ModelBase
{
    private RepositoryBase<T> RepositoryBase { get; set; }
    public ServiceBase(RepositoryBase<T> repositoryBase)
    {
        RepositoryBase = repositoryBase;
    }

    public async ValueTask<T> AddAsync(T model)
    {
        if (model is not null)
            return await RepositoryBase.CreatAsync(model);
        throw new Exception("Model in not valid");
    }

    public async ValueTask<T> DeleteAsync(int id)
    {
        var res =await GetByIdAsync(id);
        if (res is T)
        {
          return await RepositoryBase.DeleteAsync(res);
        }
        throw new Exception("Model in not valid");
    }

    public async ValueTask<T> GetByIdAsync(int id)
    {
        return await RepositoryBase.GetByIdAsync(id);
    }

    public async ValueTask<T> UpdateAsync(T model)
    {
        if (model is T)
        {
          return  await RepositoryBase.UpdateAsync(model);
        }
        throw new Exception("Model in not valid");
    }

    public async ValueTask<List<T>> GetAllAsync()
    {
        return (List<T>)await RepositoryBase.GetAllAsync();
    }
}
