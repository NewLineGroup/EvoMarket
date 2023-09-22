using System.Threading.Tasks;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface IClientService : IServiceBase<Client>
{
    public ValueTask<long> GetNewClientId();
}