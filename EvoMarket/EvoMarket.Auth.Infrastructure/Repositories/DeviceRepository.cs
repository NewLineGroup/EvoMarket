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

    public ValueTask<List<Device>> GetUserDevices(int userId)
    {
        var devices = GetAllAsync().Result.ToList();
        return ValueTask.FromResult(devices.Where(device => device.Id == userId).ToList());
    }
}