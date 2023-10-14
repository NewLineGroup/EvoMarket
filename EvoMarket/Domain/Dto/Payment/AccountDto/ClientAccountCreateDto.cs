using Domain.Entities.Shops;

namespace Domain.Dto.Payment.AccountDto;

public class ClientAccountCreateDto
{
    public bool is_Freeze { get; set; }
    public long ClientId { get; set; }
    public long ClientAccountId { get; set; }
    public decimal Money { get; set; }
}