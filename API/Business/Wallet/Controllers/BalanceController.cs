namespace API.Business.Wallet.Controllers
{
    using API.Business.Wallet.DTOs;
    using API.Business.Wallet.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            this.balanceService = balanceService;
        }

        [HttpGet("wallet/{walletId}/balance")]
        public IEnumerable<BalanceChangeDto> Get([FromRoute] Guid walletId)
        {
            return balanceService.GetByWallet(walletId);
        }

        [HttpPost("wallet/{walletId}/balance")]
        public async Task<BalanceChangeDto> Add([FromRoute] Guid walletId, [FromBody] BalanceChangeCreateRequestDto dto)
        {
            dto.WalletId = walletId;
            return await balanceService.Create(dto);
        }

        [HttpDelete("balance/{balanceId}")]
        public ActionResult Delete(Guid balanceId)
        {
            return balanceService.Delete(balanceId) ? this.Ok() : this.NotFound();
        }
    }
}