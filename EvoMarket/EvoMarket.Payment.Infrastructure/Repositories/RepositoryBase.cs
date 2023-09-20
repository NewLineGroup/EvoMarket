using Domain;
using EvoMarket.Payment.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.Repositories;

public class RepositoryBase<T> :  IRepositoryBase<T> where T : ModelBase
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }
    public DbSet<T> GetAll()
    {
        return this._context.Set<T>();
    }

    public async ValueTask<T?> GetByIdAsync(long id)
    {
        return await this.GetAll().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async ValueTask<T> CreateAsync(T entity)
    {
        var result = await GetAll().AddAsync(entity);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async ValueTask<T> UpdateAsyc(T entity)
    {
        var result = GetAll().Update(entity);
        await this._context.SaveChangesAsync();

        return result.Entity;
    }

    public async ValueTask<T> DeleteAsync(T entity)
    {
        var result =  GetAll().Remove(entity);
        await this._context.SaveChangesAsync();
        return result.Entity;
    }
}