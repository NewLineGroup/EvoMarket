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
    public async ValueTask UpdateAsync([FromBody] List<long> messageIds)
    {
       await _notificationService.ReceivedMessagesAsync(messageIds);
    }
    
    [HttpPost("send-email")]
    public async ValueTask SendEmailAsync([FromBody] EmailDto dto )
    {
        await _notificationService.SendMailAsync(dto.AddressTo, dto.MailSubject, dto.MailBody);
    }

    [HttpGet("get_all_new_messages")]

    public async ValueTask<List<ClientNotification>> GetAllNewMessagesAsync(long clientId)
    {
        return await _notificationService.GetAllMassagesAsync(clientId);
    }
}