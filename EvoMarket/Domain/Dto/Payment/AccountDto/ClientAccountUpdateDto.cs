namespace Domain.Dto.Payment.AccountDto;

public class ClientAccountUpdateDto
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public bool IsFreeze { get; set; }

}