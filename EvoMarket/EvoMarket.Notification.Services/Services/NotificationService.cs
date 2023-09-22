using System.Net;
using System.Net.Mail;
using Domain.Entities.Notification;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.Notification.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Notification.Services.Services;

public class NotificationService : INotificationService
{
    private readonly SmtpClient client;
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(SmtpClient smtpClient, INotificationRepository notificationRepository)
    {
        client = smtpClient;
        _notificationRepository = notificationRepository;
    }
    public async ValueTask SendMailAsync(string addressTo,  string mailSubject, string mailBody)
    {
        string addressFrom = "evomarket777@gmail.com";
        
        MailAddress from = new MailAddress(addressFrom);
        MailAddress to = new MailAddress(addressTo);
        MailMessage message = new MailMessage(from, to);
        message.Body = mailBody;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.Subject = mailSubject;
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        client.SendAsync(message, CancellationToken.None);
    }

    public async ValueTask<ClientNotification> CreateClientNotificationMessagesAsync(string message, long ClientId)
    {
        var insertMessage = new ClientNotification()
        {
            ClientId = ClientId,
            CreatedAt = DateTime.Now,
            message = message,
            Received = false,
        };
        var result = await _notificationRepository.CreatAsync(insertMessage);
        
        if (result is null)
            throw new Exception("Uneble to add model ");
        return result;
    }

    public async ValueTask<List<ClientNotification>> GetAllMassagesAsync(long ClientId)
    {
       var result= _notificationRepository
           .DbGetSet()
           .Where(x => x.ClientId == ClientId && x.Received == false)
           .ToList();
       return result;
    }

    public async ValueTask ReceivedMessagesAsync(List<long> messageIds)
    {
        var result = await _notificationRepository
            .DbGetSet()
            .Where(notification => messageIds.Contains(notification.Id))
            .ToListAsync();
        
        for (var i = 0; i < result.Count; i++)
        {
            result[i].Received = true;
        }
    }
}