using System.Net;
using System.Net.Mail;
using Domain.Entities.Notification;

namespace EvoMarket.Notification.Services.Interfaces;

public interface INotificationService
{
    public ValueTask SendMailAsync(string addressTo, string mailSubject, string mailBody);

    public ValueTask<ClientNotification> CreateClientNotificationMessagesAsync(string message, long ClientId);

    public ValueTask<List<ClientNotification>> GetAllMassagesAsync(long ClientId);

    public ValueTask ReceivedMessagesAsync(List<long> MessageIds);

}