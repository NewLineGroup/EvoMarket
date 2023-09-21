using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;

namespace Shop.Repositories;

public class ClientRoleRepository : RepositoryBase<ClientRole>, IClientRoleRepostiroy
{
    public ClientRoleRepository(DataContext context) : base(context)
    {
    }
}