using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer
{
    public class UserDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CA4T698\SQLEXPRESS;Database=UsersDB;uid=sa;pwd=1234;Trust Server Certificate=true;");
        }

        public DbSet<User> Users { get; set; }

    }
}
