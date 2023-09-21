using System.Net;
using System.Net.Mail;
using EvoMarket.Notification.Services.Interfaces;

namespace EvoMarket.Notification.Services.Services;

public class NotificationService : INotificationService
{
    public async Task<string> SendMessageToEmail(string email, string text)
    {
        {
             var smtpClient = new SmtpClient("smtp.gmail.com") 
            { Port = 587, Credentials = new NetworkCredential("evomarket777@gmail.com", "hcsm ymjx iyhf hgxm"),
                EnableSsl = true, }; smtpClient. Send("evomarket777@gmail.com", email, "Notifications", text);
            return text;
        }
    }

    public async Task<string> CheckEmail(string email)
    {
        {
               string verificationCode = new Random().Next(100000, 999999).ToString();
               string messageToEmail = @"You log into Evo Market via Evo ID.
       Your verification code:" + verificationCode + "Please do not share this code with anyone.";
               var smtpClient = new SmtpClient("smtp.gmail.com") 
               { Port = 587, Credentials = new NetworkCredential("evomarket777@gmail.com", "hcsm ymjx iyhf hgxm"),
                   EnableSsl = true, }; smtpClient. Send("evomarket777@gmail.com", email, "verification code", messageToEmail);
               return verificationCode;
        }
    }
}