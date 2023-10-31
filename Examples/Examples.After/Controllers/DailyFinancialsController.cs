using Examples.Before.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DailyFinancialsController : ControllerBase
{
    private readonly IFinancialDataService _financialDataService;

    public DailyFinancialsController(IFinancialDataService financialDataService)
    {
        _financialDataService = financialDataService;
    }

    [HttpPost]
    [Route("GetMetricsData")]
    public IActionResult GetMetricsData(List<string> tickers)
    {
        try
        {
            var result = _financialDataService.GetMetrics(tickers);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("GetRanksData")]
    public IActionResult GetRanksData(List<string> tickers)
    {
        try
        {
            var result = _financialDataService.GetRanks(tickers);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return BadRequest();
        }
    }
}
