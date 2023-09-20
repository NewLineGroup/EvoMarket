using Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.BaseWebApi.Interfaces;

public interface IRepositoryBase<T> where T : ModelBase
{
    public DbSet<T> GetSet();
    public ValueTask<IEnumerable<T>> GetAllAsync();
    public ValueTask<T> GetByIdAsync(long id);
    public ValueTask<T> CreatAsync(T data);
    public ValueTask<T> UpdateAsync(T data);
    public ValueTask<T> DeleteAsync(T data);
    public ValueTask<T> DeleteAsync(long id);
}