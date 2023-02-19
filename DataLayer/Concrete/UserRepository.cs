using DataLayer.Abstract;
using Models;

namespace DataLayer.Concrete
{
    public class UserRepository : IUserRepository
    {
        public List<User> AllUsers()
        {
            using (UserDbContext db = new UserDbContext())
            {
                return db.Users.ToList();
            }
        }

        public bool CreateUser(User user)
        {
           using(UserDbContext db = new UserDbContext())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }catch(Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using(UserDbContext db = new UserDbContext())
            {
                User user=GetUserById(id);
                if(user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public User GetUserById(int id)
        {
            using (UserDbContext db = new UserDbContext())
            {
                return db.Users.Find(id);
            }
        }

        public bool UpdateUser(User user)
        {
            using(UserDbContext db = new UserDbContext())
            {
                if(this.GetUserById(user.UserId) != null) {
                    db.Users.Update(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
