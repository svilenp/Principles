using Examples.After.SOLID.SRP;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Examples.After.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FinancialReportingController : ControllerBase
{
    private readonly IFinancialDataService _financialDataService;

    public FinancialReportingController(IFinancialDataService financialDataService)
    {
        _financialDataService = financialDataService;
    }

    [HttpPost]
    [Route("ExportData")]
    public IActionResult ExportData(List<string> tickers)
    {
        try
        {
            var finModels = _financialDataService.GetMetrics(tickers);
            var result = _financialDataService.ExportData(finModels);

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
            var currentUserEmail = GetCurrentUserEmail();

            if (string.IsNullOrEmpty(currentUserEmail))
            {
                return BadRequest("User email not found.");
            }

            var result = _financialDataService.SendData(finModels, currentUserEmail);

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

    private string GetCurrentUserEmail()
    {
        // Get the current user from the user claims identity
        // NOTE: This requires authentication mechanism to be set up and [Authorize] attribute 
        return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "dummy@livethecode.com";
    }
}
