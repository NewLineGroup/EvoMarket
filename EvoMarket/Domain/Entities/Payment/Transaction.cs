using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payment;

[Table("transactions")]
public class Transaction : ModelBase
{
    [Required]
    [Column("account_id")]
    public long AccountId { get; set; }
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("date_time")]
    public DateTime Time { get; set; }
    [Column("success")]
    public bool Success { get; set; }
}