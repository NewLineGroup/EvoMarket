namespace Domain.Dto.Payment.TransactionDto;

public class TransactionUpdateDto
{
    public DateTime Time { get; set; }
    public decimal Amount { get; set; }
    public bool Success { get; set; }
    
    public long Id { get; set; }
}