using Domain.Entities.Auth;
using EvoMarket.Auth.Infrastructure.Repositories;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Auth.Service.Services;

public class DeviceService:ServiceBase<Device>
{
    private DeviceRepository DeviceRepository { get; set; }
    public DeviceService(RepositoryBase<Device> repositoryBase) : base(repositoryBase)
    {
        DeviceRepository =(DeviceRepository) repositoryBase;
    }

    public async ValueTask<bool> CheckDevicesCount(int userId)
    {
        var devices =await DeviceRepository.GetUserDevices(userId);
        if (devices.Count>3)
        {
            return true;
        }
        return false;
    }

    public async ValueTask<Device> DeleteDeviceByCreatedDate(int userId)
    {
        var devices =await DeviceRepository.GetUserDevices(userId);
        if (devices.Count>3)
        {
            var minDeviceId = devices.MinBy(device => device.LastLoginDate)!.Id;
           return await DeleteAsync((int)minDeviceId);
        }

        throw new Exception("The number of devices is less than 3");
    }
}

