using Domain.Entities.Notification;
using EvoMarket.Notification.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.Notification.Api.Controllers;

public class NotificationController : Controller

{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("create")]
    public async ValueTask<ClientNotification> CreateAsync(string message, long clientId)
    {
       return  await _notificationService.CreateClientNotificationMessagesAsync(message, clientId);
    }

    [HttpPut("update")]
    public async ValueTask UpdateAsync(List<long> messageIds)
    {
       await _notificationService.ReceivedMessagesAsync(messageIds);
    }
    
    [HttpPost("send_email")]
    public async ValueTask SendEmailAsync(string addressTo,  string mailSubject, string mailBody )
    {
        await _notificationService.SendMailAsync(addressTo, mailSubject, mailBody);
    }

    [HttpGet("get_all_new_messages")]

    public async ValueTask<List<ClientNotification>> GetAllNewMessagesAsync(long clientId)
    {
        return await _notificationService.GetAllMassagesAsync(clientId);
    }
}