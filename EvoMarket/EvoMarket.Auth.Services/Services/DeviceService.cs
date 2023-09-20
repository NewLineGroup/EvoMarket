
using EvoMarket.Auth.Infrastructure.Context;
using EvoMarket.Auth.Infrastructure.DataServices;
using OnlineShop.Domain.Models;

namespace EvoMarket.AuthServices.Services;

public class DeviceService
{
  private DeviceDataService _deviceDataService { get; set; }

  public DeviceService(AuthDataContext authDataContext)
  {
    _deviceDataService = new DeviceDataService(authDataContext);
  }

  public async Task<Device?> AddDevice(Device device)
  {
    if (device is Device)
    {
     return await _deviceDataService.AddDevice(device);
    }

    return null;
  }

  public async Task<List<Device?>> GetAllDevices()
  {
    return await _deviceDataService.GetAllDevices();
  }

  public async Task<List<Device?>> GetUserDevices(int userId)
  {
    return await _deviceDataService.GetUserDevices(userId);
  }

  public async Task<List<Device>?> GetDevicesByDateTime(DateTime time)
  {
    var devices =await GetAllDevices();
    if (devices is not null)
    {
      return devices.Where(device => device.LasLogDate == time).ToList();
    }
    return null;
  }
  
  public  async Task<List<Device>?> GetDevicesByDateTime(DateTime startTime,DateTime endTime)
  {
    var devices =await GetAllDevices();
    if (devices is not null)
    {
      return devices.Where(device => device.LasLogDate > startTime && device.LasLogDate<endTime).ToList();
    }
    return null;
  }
  public async Task<Device?> GetDeviceById(int id)
  {
    return await _deviceDataService.GetById(id);
  }

  public async Task<int> DeleteDevice(int deviceId)
  {
    var device =await GetDeviceById(deviceId);
    if (device is not null)
    {
     return await _deviceDataService.DeleteDevice(device);
    }

    return 0;
  }
  
    
}