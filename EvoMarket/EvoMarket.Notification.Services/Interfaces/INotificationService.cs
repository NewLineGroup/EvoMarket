using System.Net;
using System.Net.Mail;

namespace EvoMarket.Notification.Services.Interfaces;

public interface INotificationService
{
    public Task<string> SendMessageToEmail(string email , string text);

    public Task<string> CheckEmail(string email);
    
    

}