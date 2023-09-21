using Domain.Entities.Shops;
using EvoMarket.Shop.Service.Interfaces;
using Shop.Interfaces;

namespace EvoMarket.Shop.Service.Services;

public class ClientRoleService : ServiceBase<ClientRole>, IClientRoleService
{
    public ClientRoleService(IClientRoleRepository repository) : base(repository)
    {
    }
}