using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class ClientService : ServiceBase<Client>, IClientService
{
    private IClientRepository _repository;
    public ClientService(IClientRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async ValueTask<long> GetNewClientId()
    {
        Client client = await _repository.CreatAsync(new Client());
        return client.Id;
    }
}