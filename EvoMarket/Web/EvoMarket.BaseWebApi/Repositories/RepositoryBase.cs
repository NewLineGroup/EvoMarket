using Domain;
using Microsoft.EntityFrameworkCore;
using OnlineShop.BaseWebApi.Interfaces;

namespace OnlineShop.BaseWebApi.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public DbSet<T> GetSet()
    {
        return _context.Set<T>();
    }

    public async ValueTask<IEnumerable<T>> GetAllAsync()
    {
        return await GetSet().ToListAsync();
    }

    public async ValueTask<T> GetByIdAsync(long id)
    {
        T data = GetSet().Where(x => x.Id == id).FirstOrDefault();
        if (data is null)
            throw new Exception("Data not fount");
        return data;
    }

    public async ValueTask<T> CreatAsync(T data)
    {
        var entityResult = GetSet().Add(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> UpdateAsync(T data)
    {
        var entityResult = GetSet().Update(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> DeleteAsync(T data)
    {
        var entityResult = GetSet().Remove(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> DeleteAsync(long id)
    {
        var data = await GetByIdAsync(id);
        var entityResult = GetSet().Remove(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }
}