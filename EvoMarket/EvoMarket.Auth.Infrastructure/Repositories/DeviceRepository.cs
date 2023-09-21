using Domain.Entities.Auth;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Infrastructure.Repositories;


public class DeviceRepository:RepositoryBase<Device>
{
    public DeviceRepository(DbContext context) : base(context)
    {
    }
    
}