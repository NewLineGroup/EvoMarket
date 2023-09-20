using Domain.Entities.Shops;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Reositories;

public class ClientRepository:RepositoryBase<Client>,IClientRepository
{
    public ClientRepository(DbContext context) : base(context)
    {
    }
}