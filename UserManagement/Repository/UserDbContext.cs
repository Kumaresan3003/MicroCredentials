namespace UserManagement.Repository
{
    using Microsoft.EntityFrameworkCore;
    using UserManagement.Models;

    /// <summary>
    /// Class for UserDbContext.
    /// </summary>
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetailModel> UserDetails { get; set; }

    }
}
