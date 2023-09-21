namespace Domain.Dto.Payment.Transaction;

public class TransactionCreateDto
{
    public long ClientId { get; set; }
    public decimal Money { get; set; }
}