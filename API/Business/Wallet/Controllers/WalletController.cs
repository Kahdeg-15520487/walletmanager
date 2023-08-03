using API.Business.Wallet.DTOs;
using API.Business.Wallet.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Business.Wallet.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService WalletService;

        public WalletController(IWalletService WalletService)
        {
            this.WalletService = WalletService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(WalletService.GetAllByUserIdpId(HttpContext.GetUserIdpId()));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public WalletDto GetById(Guid id)
        {
            return WalletService.GetById(HttpContext.GetUserIdpId(), id);
        }

        [HttpPost]
        public async Task<WalletDto> CreateWallet([FromBody] WalletCreateRequestDto dto)
        {
            return await WalletService.Create(dto, HttpContext.GetUserIdpId());
        }
    }
}