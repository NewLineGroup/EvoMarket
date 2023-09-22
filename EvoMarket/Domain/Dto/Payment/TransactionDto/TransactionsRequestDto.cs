namespace Domain.Dto.Payment.AccountDto;

public class TransactionsRequestDto
{
    public long ClientAccountId { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
}