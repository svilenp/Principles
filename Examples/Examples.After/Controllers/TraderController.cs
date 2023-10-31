using Examples.Before.Interfaces;
using Examples.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TraderController : ControllerBase
{
    private readonly ITradeService _tradeService;
    private readonly INotificationService _notificationService;

    public TraderController(ITradeService tradeService, INotificationService notificationService)
    {
        _tradeService = tradeService;
        _notificationService = notificationService;
    }

    [HttpGet]
    [Route("Buy")]
    public IActionResult BuyStock(string ticker, double count)
    {
        try
        {
            _tradeService.BuyStock(ticker, count);
            _notificationService.SendEmailAlert(ticker, MockUserService.GetCurrentUserEmail(User), "Buy");
            _notificationService.SendSmsAlert(ticker, MockUserService.GetCurrentUserPhoneNumber(User), "Buy");

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
            _tradeService.SellStock(ticker, count);
            _notificationService.SendEmailAlert(ticker, MockUserService.GetCurrentUserEmail(User), "Sell");
            _notificationService.SendSmsAlert(ticker, MockUserService.GetCurrentUserPhoneNumber(User), "Sell");

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
