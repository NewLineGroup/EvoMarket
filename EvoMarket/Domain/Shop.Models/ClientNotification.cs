using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop.Models;

[Table("cliets_notification",Schema = "shop")]
public class ClientNotification : ModelBase
{
    [Column("client_id")]
    public long ClientId { get; set; }
    [Column("message_date")]
    public DateTime MessageDate { get; set; }
    [Column("message")]
    public string Message { get; set; }
    [Column("received")]
    public bool Received { get; set; }
}