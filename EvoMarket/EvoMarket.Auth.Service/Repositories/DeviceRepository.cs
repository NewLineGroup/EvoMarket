using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Auth.Service.Repositories;


public class DeviceRepository:RepositoryBase<Device>,IDeviceRepository
{
    public DeviceRepository(DataContext context) : base(context)
    {
    }

    public ValueTask<List<Device>> GetUserDevices(long userId)
    {
        var devices = GetAllAsync().Result.ToList();
        return ValueTask.FromResult(devices.Where(device => device.Id == userId).ToList());
    }
}