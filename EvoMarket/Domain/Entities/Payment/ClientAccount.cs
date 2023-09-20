using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shop.Models;

namespace Domain.Payment.Models;

[Table("client_account")]
public class ClientAccount :  ModelBase
{
    [Required]
    [Column("balance")]
    public decimal Balance { get; set; }
    [Column("is_freeze")]
    public bool IsFreeze { get; set; }
    [Column("client_id")]
    public long ClientId { get; set; }

    [NotMapped]
    public Client Client { get; set; }
    [NotMapped]
    public ICollection<Transactions> Transactions { get; set; }
}
