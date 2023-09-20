using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Shops;

namespace Domain.Entities.Payment;

[Table("client_account")]
public class ClientAccount : ModelBase
{
   
    [Column("balance")]
    public decimal Balance { get; set; }
    [Column("is_freeze")]
    public bool IsFreeze { get; set; }
    
    [Column("client_id")]
    public long ClientId { get; set; }

    [NotMapped]
    public Client Client { get; set; }
}