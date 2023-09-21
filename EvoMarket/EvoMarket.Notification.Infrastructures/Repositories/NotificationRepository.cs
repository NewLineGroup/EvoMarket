using Domain.Entities.Notification;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Notification.Infrastructures.Repositories;

public class NotificationRepository : RepositoryBase<ClientNotifications> , INotificationRepository
    
{
    public NotificationRepository(DbContext context) : base(context)
    {
    }
}