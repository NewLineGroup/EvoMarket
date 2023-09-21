using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class ClientRepository:RepositoryBase<Client>,IClientRepository
{
    public ClientRepository(DataContext context) : base(context)
    {
    }

    public async ValueTask<long> GetNewClientId()
    {
        Client client = await base.CreatAsync(
            new Client());
        return client.Id;
    }
}