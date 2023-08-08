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
        public IEnumerable<BalanceChangeDto> GetByWallet([FromRoute] Guid walletId)
        {
            return balanceService.GetByWallet(HttpContext.GetUserIdpId(), walletId);
        }

        [HttpGet("balance/{balanceId}")]
        public BalanceChangeDto Get([FromRoute] Guid balanceId)
        {
            return balanceService.GetBalanceChange(HttpContext.GetUserIdpId(), balanceId);
        }

        [HttpPost("wallet/{walletId}/balance")]
        public async Task<BalanceChangeDto> Add([FromRoute] Guid walletId, [FromBody] BalanceChangeCreateRequestDto dto)
        {
            dto.WalletId = walletId;
            return await balanceService.Create(HttpContext.GetUserIdpId(), dto);
        }

        [HttpDelete("balance/{balanceId}")]
        public ActionResult Delete([FromRoute] Guid balanceId)
        {
            return balanceService.Delete(HttpContext.GetUserIdpId(), balanceId) ? this.Ok() : this.NotFound();
        }
    }
}