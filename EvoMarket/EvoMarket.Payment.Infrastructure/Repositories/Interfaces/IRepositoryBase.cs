using Domain;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Payment.Infrastructure.Repositories.Interfaces;

public interface IRepositoryBase<T> where T : ModelBase
{
    DbSet<T> GetAll();
    ValueTask<T?> GetByIdAsync(long id);
    ValueTask<T> CreateAsync(T entity);
    ValueTask<T> UpdateAsyc(T entity);
    ValueTask<T> DeleteAsync(T entity);
}