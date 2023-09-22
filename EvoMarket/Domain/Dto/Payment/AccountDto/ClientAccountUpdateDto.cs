namespace Domain.Dto.Payment.AccountDto;

public class ClientAccountUpdateDto
{
    public long Id { get; set; }
    public long ClientAccountId { get; set; }
    public bool IsFreeze { get; set; }

}