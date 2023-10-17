using Examples.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TraderController : ControllerBase
    {
        private readonly IFinancialDataService _financialDataService;

        public TraderController(IFinancialDataService financialDataService)
        {
            _financialDataService = financialDataService;
        }

        [HttpGet]
        [Route("Buy")]
        public IActionResult BuyStock(string ticker, double count)
        {
            try
            {
                _financialDataService.BuyStock(ticker, count);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Sell")]
        public IActionResult SellStock(string ticker, double count)
        {
            try
            {
                _financialDataService.SellStock(ticker, count);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
