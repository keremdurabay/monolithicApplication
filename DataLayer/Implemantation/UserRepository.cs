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
                return await db.Users.FindAsync(id);
            }
        }

        public async Task<int> UpdateUser(User user)
        {  
        
        //null degerleri yakalamak icin Guard clouse kullanalim
        //ve nullreference exception dondurelim
        //https://stackoverflow.com/questions/29184887/best-way-to-check-for-null-parameters-guard-clauses
        
        //her iki durumda da savechange fonksiyonu cagiriliyor bu sebeple iki kere yazmaya gerek yok 
        //best practices geregi kod tekrarindan kacinmamiz gerek
        
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
