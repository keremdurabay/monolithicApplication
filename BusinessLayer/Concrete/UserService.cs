using BusinessLayer.Abstract;
using DataLayer.Abstract;
using DataLayer.Concrete;
using Models;
namespace BusinessLayer.Concrete
{
    public class UserService : IUserService 
    {
        private IUserRepository UserRepository;

        public UserService()
        {
            this.UserRepository = new UserRepository();
        }

        public List<User> AllUsers()
        {
            return this.UserRepository.AllUsers();
        }

        public bool CreateUser(User user)
        {
            return this.UserRepository.CreateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return this.UserRepository.DeleteUser(id);
        }

        public User GetUserById(int id)
        {
            return this.UserRepository.GetUserById(id);
        }

        public List<User> GetUserNamesStartsWith(string letter)
        {
            List<User> users = this.UserRepository.AllUsers();
            List<User> new_users= new List<User>();
            foreach (User user in users)
            {
                if (user.firstName.StartsWith(letter))
                {
                    new_users.Add(user);
                }
            }
            return new_users;
        }

        public bool UpdateUser(User user)
        {
            return this.UserRepository.UpdateUser(user);
        }
    }
}
