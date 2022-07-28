using API.Business.Wallet.DTOs;

namespace API.Business.Wallet.Services.Interfaces
{
    public interface IBalanceService
    {
        BalanceChangeDto GetById(Guid id);
        IEnumerable<BalanceChangeDto> GetAll();
        BalanceChangeDto Create(BalanceChangeDto dto);
        bool Delete(Guid id);
        bool Update(BalanceChangeDto dto);
    }
}
