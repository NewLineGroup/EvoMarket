using System.Threading.Tasks;
using Domain.Dto.Payment.AccountDto;
using Domain.Dto.Payment.TransactionDto;

namespace EvoMarket.Payment.Service.Service;

public interface ITransactionService
{
    ValueTask<TransactionUpdateDto> TransactionAsync(TransactionCreateDto transactionCreateDto);

    ValueTask<TransactionsResponseDto> GetByIdAndTimeAsync(TransactionsRequestDto transactionsRequestDto);
}