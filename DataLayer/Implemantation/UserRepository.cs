using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer.Implemantation
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

        public async Task<int> DeleteUser(int id)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var user = await GetUserById(id);

                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                db.Users.Remove(user);
                return await db.SaveChangesAsync();


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



        public async Task<User> GetUserById(int id)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                return user;
            }
        }

        public async Task<int> UpdateUser(User user)
        {
            using (UserDbContext db = new UserDbContext())
            {
                _ = await this.GetUserById(user.UserId) ?? throw new ArgumentNullException(nameof(user));
                db.Users.Update(user);

                return await db.SaveChangesAsync();


            }
        }
    }
}
