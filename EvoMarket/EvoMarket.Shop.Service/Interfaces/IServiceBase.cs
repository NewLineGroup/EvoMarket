namespace EvoMarket.Shop.Service.Interfaces;

public interface IServiceBase<T>
{
    public ValueTask<IEnumerable<T>> GetAll();
    public ValueTask<T> GetById(long id);
    public ValueTask<T> Create(T data);
    public ValueTask<T> Update(T data);
    public ValueTask<T> Delete(T data);
    public ValueTask<T> Delete(long id);

}