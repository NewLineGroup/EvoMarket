using Domain.Entities.Auth;
using EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;
using EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;
using EvoMarket.Auth.Service.Repositories;
using EvoMarket.WebCore.Interfaces;
using EvoMarket.WebCore.Repositories;

namespace EvoMarket.Auth.Service.Services;

public class DeviceService:IDeviceService
{
    private IDeviceRepository _deviceRepository { get; set; }
    public DeviceService(IDeviceRepository repositoryBase) 
    {
        _deviceRepository = repositoryBase;
    }

    public async ValueTask<bool> CheckDevicesCount(int userId)
    {
        var devices =await _deviceRepository.GetUserDevices(userId);
        if (devices.Count>3)
        {
            return true;
        }
        return false;
    }

    public async ValueTask<Device> DeleteDeviceByCreatedDate(int userId)
    {
        var devices =await _deviceRepository.GetUserDevices(userId);
        if (devices.Count>3)
        {
            var minDeviceId = devices.MinBy(device => device.LastLoginDate)!.Id;
           return await _deviceRepository.DeleteAsync((int)minDeviceId);
        }

        throw new Exception("The number of devices is less than 3");
    }

    public async ValueTask<Device?> GetDeviceByDeviceName(string deviceName, string deviceIp)
    {
        var devices =await _deviceRepository.GetAllAsync();

        return devices.FirstOrDefault(device => device.DeviceName == deviceName && device.Ip == deviceIp);

    }
}

