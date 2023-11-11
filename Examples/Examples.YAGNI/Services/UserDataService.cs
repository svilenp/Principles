using Examples.YAGNI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Examples.YAGNI.Services;

public class UserDataService : IUserDataService
{
    private readonly UserDbContext _dbContext;
    private readonly IMemoryCache _memoryCache;

    public UserDataService(UserDbContext dbContext, IMemoryCache memoryCache)
    {
        _dbContext = dbContext;
        _memoryCache = memoryCache;
    }

    public User Get()
    {
        /**** NOTE: The following code violates YAGNI principle and may introduce errors if not considered in the future development 
                    The caching mechanism is not required in the initial requirement so it is not needed to be added here ****/
        if (_memoryCache.TryGetValue("UserData", out User cachedUser))
        {
            return cachedUser;
        }
        /**** ****/

        // If not in cache, get the user from the database
        var user = _dbContext.Users.FirstOrDefault();

        if (user == null)
        {
            // Add a default/dummy user in the sake of the example
            user = new User
            {
                Id = 6,
                Name = "John Doe",
                Age = 30,
                Height = 175.0,
                Weight = 70.0
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        /**** NOTE: The following code violates YAGNI principle and may introduce errors if not considered in the future development ****/
        _memoryCache.Set("UserData", user, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Set cache expiration time
        });
        /**** Furthermore this can lead to a memory problem in a real life example, where there might be a lot of users.
            * Caching every user's data can consume a significant amount of memory, especially if the number of active users is high.****/

        return user;
    }

    public void UpdateWeight(double newWeight, int id)
    {
        var user = GetUserById(id);

        if (user != null)
        {
            // Update the Weight value
            user.Weight = newWeight;
            _dbContext.SaveChanges();
        }

        /**** NOTE: If this is done by second developer who doesn't know about the introduction of the not-required caching 
         * they should do the following: ****/
        //// Update the cached user
        //_memoryCache.Set("UserData", user);
    }

    public User GetUserById(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

        return user;
    }
}
