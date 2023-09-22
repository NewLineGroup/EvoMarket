using System.Net;
using System.Net.Mail;
using Domain.Entities.Notification;

namespace EvoMarket.Notification.Services.Interfaces;

public interface INotificationService
{
    public Task SendMail(string addressTo, string mailSubject, string mailBody);

    public Task<ClientNotification> CreateClientNotificationMessages(string message, long ClientId);

    public Task<List<ClientNotification>> GetAllMassages(long ClientId);

    public Task ReceivedMessages(List<long> MessageIds);

}