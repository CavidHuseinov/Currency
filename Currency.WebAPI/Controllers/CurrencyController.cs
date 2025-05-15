using Currency.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Currency.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;

        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetCurrency()
        {
            var currency = await _service.GetCurrency();
            return Ok(currency);
        }
    }
}
