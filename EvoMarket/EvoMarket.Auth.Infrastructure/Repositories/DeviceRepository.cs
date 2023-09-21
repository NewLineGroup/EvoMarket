using Domain.Entities.Auth;
using EvoMarket.Auth.Infrastructure.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Infrastructure.Repositories;


public class DeviceRepository:RepositoryBase<Device>,IDeviceRepository
{
    public DeviceRepository(DbContext context) : base(context)
    {
    }
    
}