using Domain.Entities.Shops;
using EvoMarket.Infrastructure.DbContexts;
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
}