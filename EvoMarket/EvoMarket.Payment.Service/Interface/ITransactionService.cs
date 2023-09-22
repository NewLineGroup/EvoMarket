using System.Threading.Tasks;
using Domain.Dto.Payment.TransactionDto;

namespace EvoMarket.Payment.Service.Service;

public interface ITransactionService
{
    ValueTask<TransactionUpdateDto> Transaction(TransactionCreateDto transactionCreateDto);
}