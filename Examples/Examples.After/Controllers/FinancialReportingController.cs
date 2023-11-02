using Examples.After.SOLID.SRP;
using Examples.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.After.Controllers;

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
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "ExportedData.xlsx"; 

                return File(result, contentType, fileName);
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
