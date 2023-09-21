using System.Net;
using System.Net.Mail;

namespace EvoMarket.Notification.Services.Interfaces;

public interface INotificationService
{
    public Task SendMail(string addressTo, string mailSubject, string mailBody);



}