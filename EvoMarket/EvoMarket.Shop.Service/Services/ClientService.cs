using System;
using Domain.Dto.ShopDto;
using System.Threading.Tasks;
using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using EvoMarket.WebCore.Repositories;
using Shop.Interfaces;
using Shop.Repositories;

namespace EvoMarket.Shop.Service.Services;

public class ClientService : ServiceBase<Client>, IClientService
{
    public ClientService(IClientRepository repository) : base(repository)
    {
    }

    public async ValueTask<long> GetNewClientId()
    {
        Client client = await _repositoryBase.CreatAsync(new Client());
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
        return await _repositoryBase.CreatAsync(client);
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
        return await _repositoryBase.UpdateAsync(client);
    }
}