using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Payment.Models;

[Table("transactions")]
public class Transactions : ModelBase
{
    [Required]
    [Column("amount")]
    public decimal Amount { get; set; }
    [Column("date_time")]
    public DateTime Time { get; set; }
    [Column("success")]
    public bool Success { get; set; }
    
    [Column("account_id")]
    public long AccountId { get; set; }

    [NotMapped]
    public ClientAccount Account { get; set; }
}