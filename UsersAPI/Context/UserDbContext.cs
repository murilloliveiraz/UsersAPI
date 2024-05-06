using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data.Models;

namespace UsersAPI.Context
{
    public class UserDbContext: IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {
            
        }
    }
}
