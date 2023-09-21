using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("carts", Schema = "shop")]
public class Cart : AuditableModelBase
{
    [Column("total_emount")] public decimal TotalEmount { get; set; }
    [Column("total_count")] public int TotalCount { get; set; }
    [Column("client_id")] public long ClientId { get; set; }
    [Column("transaction_id")] public long TransactionId { get; set; }
    [Column("closed")] public bool Closed { get; set; }
}