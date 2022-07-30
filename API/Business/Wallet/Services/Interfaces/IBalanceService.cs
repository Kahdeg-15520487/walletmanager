using API.Business.Wallet.DTOs;

namespace API.Business.Wallet.Services.Interfaces
{
    public interface IBalanceService
    {
        IEnumerable<BalanceChangeDto> GetByWallet(Guid walletId);
        Task<BalanceChangeDto> Create(BalanceChangeCreateRequestDto dto);
        bool Delete(Guid balanceChangeId);
        bool Update(BalanceChangeDto dto);
    }
}
