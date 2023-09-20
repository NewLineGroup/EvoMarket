using Domain.Entities.Shops;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Notification.Repositoreis;

public class NotificationRepository : RepositoryBase<ClientNotification>
{
    public NotificationRepository(DbContext context) : base(context)
    {
    }
}