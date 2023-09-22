using System.Net;
using System.Net.Mail;
using Domain.Entities.Notification;
using EvoMarket.Infrastructure.DbContexts;
using EvoMarket.Notification.Infrastructures.Interfaces;
using EvoMarket.Notification.Services.Interfaces;

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
    public async Task SendMail(string addressTo,  string mailSubject, string mailBody)
    {
        string addressFrom = "evomarket777@gmail.com";
        
        NetworkCredential myCredential = new NetworkCredential("evomarket777@gmail.com", "hcsm ymjx iyhf hgxm");

        
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = myCredential;
        client.EnableSsl = true;

        MailAddress from = new MailAddress(addressFrom);
        MailAddress to = new MailAddress(addressTo);
        MailMessage message = new MailMessage(from, to);
        message.Body = mailBody;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.Subject = mailSubject;
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        client.Send(message);
        
    }

    public async Task<ClientNotification> CreateClientNotificationMessages(string message, long ClientId)
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

    public async Task<List<ClientNotification>> GetAllMassages(long ClientId)
    {
       var result= _notificationRepository
           .DbGetSet()
           .Where(x => x.ClientId == ClientId)
           .ToList();
       return result;
    }

    public Task ReceivedMessages(List<long> MessageIds)
    {
        var resutl = _notificationRepository
            .DbGetSet();
        return null;
    }
}