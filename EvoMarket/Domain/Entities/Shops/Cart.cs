using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Payment;

namespace Domain.Entities.Shops;

[Table("carts", Schema = "shop")]
public class Cart : AuditableModelBase
{
    [Column("total_amount")] public decimal TotalAmount { get; set; }
    [Column("total_count")] public int TotalCount { get; set; }
    [Column("client_id"), ForeignKey(nameof(Client))] public long ClientId { get; set; }
    public Client Client { get; set; }
    [Column("transaction_id"), ForeignKey(nameof(Transaction))] public long TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    [Column("closed")] public bool Closed { get; set; }
}