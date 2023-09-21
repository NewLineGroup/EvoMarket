namespace EvoMarket.Shop.Service.Interfaces;

public interface IServiceBase<T>
{
    public ValueTask<IEnumerable<T>> GetAllAsync();
    public ValueTask<T> GetByIdAsync(long id);
    public ValueTask<T> CreateAsync(T data);
    public ValueTask<T> UpdateAsync(T data);
    public ValueTask<T> DeleteAsync(T data);
    public ValueTask<T> DeleteAsync(long id);

}