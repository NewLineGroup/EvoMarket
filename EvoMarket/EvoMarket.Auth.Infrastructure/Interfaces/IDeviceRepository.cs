using Domain.Entities.Auth;
using EvoMarket.WebCore.Interfaces;

namespace EvoMarket.Auth.Infrastructure.Interfaces;

public interface IDeviceRepository : IRepositoryBase<Device>
{
    public ValueTask<List<Device>> GetUserDevices(int userId);
}