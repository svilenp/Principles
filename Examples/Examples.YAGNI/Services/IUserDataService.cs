using Examples.YAGNI.Models;

namespace Examples.YAGNI.Services;

public interface IUserDataService
{
    User Get();
    void UpdateWeight(double newWeight, int id);
    User GetUserById(int id);
}
