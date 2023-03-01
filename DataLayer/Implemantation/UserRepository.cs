using DataLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> AllUsers()
        {
            using (UserDbContext db = new UserDbContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        public async Task<int> CreateUser(User user)
        {
            using (UserDbContext db = new UserDbContext())
            {
                await db.Users.AddAsync(user);
                return await db.SaveChangesAsync();

            }
        }

        public async Task<int> DeleteUser(int id)
        {
            using (UserDbContext db = new UserDbContext())
            {
                User user = await GetUserById(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    return await db.SaveChangesAsync();
                }
                else
                {
                    return await db.SaveChangesAsync();
                }
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (UserDbContext db = new UserDbContext())
            {
                return await db.Users.FindAsync(id);
            }
        }

        public async Task<int> UpdateUser(User user)
        {
            using (UserDbContext db = new UserDbContext())
            {
                if (await this.GetUserById(user.UserId) != null)
                {
                    db.Users.Update(user);

                    return await db.SaveChangesAsync();
                }
                else
                {
                    return await db.SaveChangesAsync();


                }
            }
        }
    }
}
