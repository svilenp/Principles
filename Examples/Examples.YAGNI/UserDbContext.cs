using Examples.YAGNI.Models;
using Microsoft.EntityFrameworkCore;

namespace Examples.YAGNI;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
