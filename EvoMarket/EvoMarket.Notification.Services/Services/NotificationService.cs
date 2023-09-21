using System.Net;
using System.Net.Mail;
using EvoMarket.Notification.Services.Interfaces;

namespace EvoMarket.Notification.Services.Services;

public class NotificationService : INotificationService
{
    private readonly SmtpClient client;

    public NotificationService(SmtpClient smtpClient)
    {
        client = smtpClient;
    }
    public async Task SendMail(string addressTo,  string mailSubject, string mailBody)
    {
        string addressFrom = "evomarket777@gmail.com";
        
        NetworkCredential myCredential = new NetworkCredential("evomarket777@gmail.com", "hcsm ymjx iyhf hgxm");

        
        client.Host = "99.99.127.233";
        client.Port = 417;
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

    
}