using Examples.Before.Interfaces;
using Examples.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FinancialReportingController : ControllerBase
{
    private readonly IFinancialDataService _financialDataService;
    private readonly IFinancialExportService _exportService;
    private readonly INotificationService _notificationService;

    public FinancialReportingController(
        IFinancialDataService financialDataService,
        IFinancialExportService exportService,
        INotificationService notificationService)
    {
        _financialDataService = financialDataService;
        _exportService = exportService;
        _notificationService = notificationService;
    }

    [HttpPost]
    [Route("ExportData")]
    public IActionResult ExportData(List<string> tickers)
    {
        try
        {
            var finModels = _financialDataService.GetMetrics(tickers);
            var result = _exportService.ExportData(finModels);

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
    [Route("SendData")]
    public IActionResult SendData(List<string> tickers)
    {
        try
        {
            var finModels = _financialDataService.GetMetrics(tickers);
            var currentUserEmail = MockUserService.GetCurrentUserEmail(User);

            if (string.IsNullOrEmpty(currentUserEmail))
            {
                return BadRequest("User email not found.");
            }

            var result = _notificationService.SendData(finModels, currentUserEmail);

            if (result != null)
            {
                return Ok();
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
