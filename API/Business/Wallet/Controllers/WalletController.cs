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
        public IEnumerable<WalletDto> Get()
        {
            return WalletService.GetAll();
        }

        [HttpGet("{id}")]
        public WalletDto GetById(Guid id)
        {
            return WalletService.GetById(id);
        }
    }
}