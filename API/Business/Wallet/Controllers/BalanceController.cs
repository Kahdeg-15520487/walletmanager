namespace API.Business.Wallet.Controllers
{
    using API.Business.Wallet.DTOs;
    using API.Business.Wallet.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            this.balanceService = balanceService;
        }

        [HttpGet]
        public IEnumerable<BalanceChangeDto> Get()
        {
            return balanceService.GetAll();
        }

        [HttpGet("{id}")]
        public BalanceChangeDto GetById(Guid id)
        {
            return balanceService.GetById(id);
        }

        [HttpPost]
        public BalanceChangeDto Add([FromBody] BalanceChangeDto dto)
        {
            return balanceService.Create(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return balanceService.Delete(id) ? this.Ok() : this.NotFound();
        }
    }
}