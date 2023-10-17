using Examples.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Before.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSortedAddresses()
        {
            var quickSort = new QuickSortService();

            var addressesList = MockAddressBook.Addresses.ToArray();
            quickSort.Sort(addressesList);

            return Ok(addressesList);
        }
    }
}
