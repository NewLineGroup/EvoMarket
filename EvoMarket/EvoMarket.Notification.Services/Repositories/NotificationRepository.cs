using Domain.Entities.Notification;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.WebCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Notification.Infrastructures.Repositories;
public class NotificationRepository : RepositoryBase<ClientNotification> , INotificationRepository
    
{
    public NotificationRepository(DataContext context) : base(context)
    {
    }
}