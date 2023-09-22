using Domain.Dto.ShopDto;
using System.Threading.Tasks;
using Domain.Entities.Shops;

namespace EvoMarket.Shop.Service.Interfaces;

public interface IClientService : IServiceBase<Client>
{
    public ValueTask<long> GetNewClientId();
    public ValueTask<Client> CreatAsync(ClientCreateDto data);
    public ValueTask<Client> UpdateAsync(ClientUpdateDto data);
}