using Examples.After.SOLID.DIP;
using Examples.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.After.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressBookController : ControllerBase
{
    private readonly ISortingAlgorithmService _sortingAlgorithm;

    public AddressBookController(ISortingAlgorithmService sortingAlgorithm)
    {
        _sortingAlgorithm = sortingAlgorithm;
    }

    [HttpGet]

    [Route("GetSorted")]
    public IActionResult GetSortedAddresses()
    {
        var addressesList = MockAddressBook.Addresses(10).ToArray();
        _sortingAlgorithm.Sort(addressesList);

        return Ok(addressesList);
    }
}
