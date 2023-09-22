using System.Threading.Tasks;
using Domain.Dto.Payment.AccountDto;
using Domain.Dto.Payment.TransactionDto;

namespace EvoMarket.Payment.Service.Service;

public interface IClientAccountService
{
    ValueTask<TransactionUpdateDto> TransferToTheBalance(ClientAccountCreateDto account);
}