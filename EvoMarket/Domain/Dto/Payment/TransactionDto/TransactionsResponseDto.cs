using System.Collections;
using Domain.Dto.Payment.TransactionDto;

namespace Domain.Dto.Payment.AccountDto;

public class TransactionsResponseDto
{
    public IEnumerable<TransactionUpdateDto> Transactions { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public long ClientAccountId { get; set; }
}