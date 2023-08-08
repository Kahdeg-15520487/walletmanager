using API.Business.Wallet.DTOs;

namespace API.Business.Wallet.Services.Interfaces
{
    public interface IBalanceService
    {
        BalanceChangeDto GetBalanceChange(string userIdpId, Guid balanceChangeId);
        IEnumerable<BalanceChangeDto> GetByWallet(string userIdpId, Guid walletId);
        Task<BalanceChangeDto> Create(string userIdpId, BalanceChangeCreateRequestDto dto);
        bool Delete(string userIdpId, Guid balanceChangeId);
        bool Update(string userIdpId, BalanceChangeDto dto);
    }
}
