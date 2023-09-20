using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payment;

[Table("client_account")]
public class ClientAccount : ModelBase
{
    [Required]
    [Column("client_id")]
    public long ClientId { get; set; }
    [Column("balance")]
    public decimal Balance { get; set; }
    [Column("is_freeze")]
    public bool IsFreeze { get; set; }
}