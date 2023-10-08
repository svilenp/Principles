using Examples.Interfaces;
using Examples.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Examples.Before.Controllers
{
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

        [HttpPost]
        [Route("ExportData")]
        public IActionResult ExportData(List<FinancialsModel> finModels)
        {
            try
            {
                var result = _financialDataService.ExportData(finModels);

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
        public IActionResult SendData(List<FinancialsModel> finModels)
        {
            try
            {
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
}
