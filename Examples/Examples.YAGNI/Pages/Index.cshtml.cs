using Examples.YAGNI.Models;
using Examples.YAGNI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IUserDataService _userService;

    public IndexModel(IUserDataService userService)
    {
        _userService = userService;
    }

    public User UserData { get; set; }

    public void ShowData()
    {
        UserData = _userService.Get();
    }

    public void OnGet()
    {
        ShowData();
    }

    public void OnPostShowData()
    {
        ShowData();
    }

    // Handler for updating the Weight value
    public void OnPostUpdateWeight(double newWeight, int id)
    {
        _userService.UpdateWeight(newWeight, id);

        ShowData();
    }
}
