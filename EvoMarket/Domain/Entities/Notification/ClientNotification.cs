using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Shops;

namespace Domain.Entities.Notification;

[Table("client_notifications", Schema = "notification")]
public class ClientNotification : AuditableModelBase
{
    [Column("client_id")]
    public long ClientId { get; set; }
    
    [NotMapped]
    public Client Client { get; set; }
    

    [Column("message")]
    public string message { get; set; }

    [Column("received")] public bool Received { get; set; } = false;

}