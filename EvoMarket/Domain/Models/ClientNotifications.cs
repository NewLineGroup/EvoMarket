using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models;

[Table("client_notifications")]
public class ClientNotifications : ModelBase
{
    [Column("client_id")]
    public int ClientId { get; set; }
    
     // [NotMapped]
    //public Client Client { get; set; }
    
    [Column("message_data")]
    public DateTime MessageData { get; set; }

    [Column("message")]
    public string message { get; set; }

    [Column("received")]
    public bool Received { get; set; }
    
}