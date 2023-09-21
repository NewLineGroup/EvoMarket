namespace Domain.Dto.Payment.TransactionDto;

public class TransactionCreateDto
{
    public long ClientId { get; set; }
    public decimal Money { get; set; }
}