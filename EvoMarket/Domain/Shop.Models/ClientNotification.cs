namespace Domain.Shop.Models;

public class ClientNotification : ModelBase
{
    public long ClientId { get; set; }

    public DateTime MessageDate { get; set; }

    public string Message { get; set; }

    public bool Received { get; set; }
}