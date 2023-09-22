using Domain.Dto.Notification;
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
    public async ValueTask<ClientNotification> CreateAsync([FromBody] NotificationMessageDto dto)
    {
       return  await _notificationService.CreateClientNotificationMessagesAsync(dto.Message, dto.ClientId);
    }

    [HttpPut("update")]
    public async ValueTask<bool> UpdateAsync([FromBody] List<long> messageIds)
    {
       await _notificationService.ReceivedMessagesAsync(messageIds);
       return true;
    }
    
    [HttpPost("sendemail")]
    public async ValueTask<bool> SendEmailAsync([FromBody] EmailDto dto )
    {
        await _notificationService.SendMailAsync(dto.AddressTo, dto.MailSubject, dto.MailBody);
        return true;
    }

    [HttpGet("getallnewmessages")]

    public async ValueTask<List<ClientNotification>> GetAllNewMessagesAsync(long clientId)
    {
        return await _notificationService.GetAllMassagesAsync(clientId);
    }
}