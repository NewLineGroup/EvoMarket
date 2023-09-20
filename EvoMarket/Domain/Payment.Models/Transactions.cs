namespace Domain.Payment.Models;

public class Transactions : ModelBase
{
    public long AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Time { get; set; }
    public bool Success { get; set; }
}