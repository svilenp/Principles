using Examples.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressBookController : ControllerBase
{
    private readonly QuickSortService _sortingAlgorithm;

    public AddressBookController()
    {
        _sortingAlgorithm = new QuickSortService();
    }

    [HttpGet]
    public IActionResult GetSortedAddresses()
    {
        var addressesList = MockAddressBook.Addresses.ToArray();
        _sortingAlgorithm.Sort(addressesList);

        return Ok(addressesList);
    }
}
