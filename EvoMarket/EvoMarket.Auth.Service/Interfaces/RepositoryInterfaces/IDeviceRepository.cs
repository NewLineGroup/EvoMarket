using Domain.Entities.Auth;
using EvoMarket.WebCore.Interfaces;

namespace EvoMarket.Auth.Service.Interfaces.RepositoryInterfaces;

public interface IDeviceRepository : IRepositoryBase<Device>
{
    public ValueTask<List<Device>> GetUserDevices(long userId);
}