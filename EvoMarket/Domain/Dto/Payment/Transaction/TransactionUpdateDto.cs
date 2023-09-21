namespace Domain.Dto.Payment.Transaction;

public class TransactionUpdateDto
{
    public decimal Amount { get; set; }
    public bool Success { get; set; }
    public DateTime Time { get; set; }
}