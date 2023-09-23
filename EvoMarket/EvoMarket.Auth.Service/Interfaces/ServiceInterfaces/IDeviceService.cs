using Domain.Entities.Auth;

namespace EvoMarket.Auth.Service.Interfaces.ServiceInterfaces;

public interface IDeviceService
{
    public ValueTask<bool> CheckDevicesCount(int userId);
    public ValueTask<Device> DeleteDeviceByCreatedDate(int userId);
    public ValueTask<Device?> GetDeviceByDeviceName(string deviceName,string ip);

}