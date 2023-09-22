using Domain.Dto.ShopDto;
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

    public async ValueTask<Client> CreatAsync(ClientCreateDto data)
    {
        Client client = new Client
        {
            CreatedAt = DateTime.Now,
            FirstName = data.FirstName,
            LastName = data.LastName,
            PhoneNumber = data.PhoneNumber,
            Address = data.Address,
            ProfileImage = data.ProfileImage,
            Age = data.Age
        };
        return await _repository.CreatAsync(client);
    }
    
    public async ValueTask<Client> UpdateAsync(ClientUpdateDto data)
    {
        Client client = new Client
        {
            UpdatedAt = DateTime.Now,
            FirstName = data.FirstName,
            LastName = data.LastName,
            PhoneNumber = data.PhoneNumber,
            Address = data.Address,
            ProfileImage = data.ProfileImage,
            Age = data.Age
        };
        return await _repository.UpdateAsync(client);
    }
}