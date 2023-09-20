namespace Domain.Payment.Models;

public class ClientAccount :  ModelBase
{
    public long ClientId { get; set; }
    public decimal Balance { get; set; }
    public bool IsFreeze { get; set; }
}