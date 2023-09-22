using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using EvoMarket.Auth.Service.Repositories;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Auth.Service.Services;

public class DeviceService:IDeviceService
{
    private DeviceRepository DeviceRepository { get; set; }
    public DeviceService(RepositoryBase<Device> repositoryBase) 
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
           return await DeviceRepository.DeleteAsync((int)minDeviceId);
        }

        throw new Exception("The number of devices is less than 3");
    }

    public async ValueTask<Device?> GetDeviceByDeviceName(string deviceName, string deviceIp)
    {
        var devices =await DeviceRepository.GetAllAsync();

        return devices.FirstOrDefault(device => device.DeviceName == deviceName && device.Ip == deviceIp);

    }
}

