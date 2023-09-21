using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;

namespace Shop.Interfaces;

public interface IClientRepository:IRepositoryBase<Client>
{
    public ValueTask<long> CreateDefaultClient();

}