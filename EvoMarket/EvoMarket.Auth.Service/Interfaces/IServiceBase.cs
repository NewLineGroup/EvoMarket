namespace EvoMarket.Auth.Service.Interfaces;

public interface IServiceBase<T>
{
  public ValueTask<T> AddAsync(T model);
  public ValueTask<T> DeleteAsync(int id);
  public ValueTask<T> GetByIdAsync(int id);
  public ValueTask<T> UpdateAsync(T model);
  public ValueTask<List<T>> GetAllAsync();
}