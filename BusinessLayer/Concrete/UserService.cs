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

        public async Task<List<User>> AllUsers()
        {
            return await this.UserRepository.AllUsers();
        }

        public async Task<int> CreateUser(User user)
        {
            return await this.UserRepository.CreateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await this.UserRepository.DeleteUser(id);
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.UserRepository.GetUserById(id);
        }

        public async Task<List<User>> GetUserNamesStartsWith(string letter)
        {
            List<User> new_users = new List<User>();

            foreach (User user in await this.UserRepository.AllUsers())
            {
                if (user.firstName.StartsWith(letter))
                {
                    new_users.Add(user);
                }
            }
            return new_users;
        }

        public async Task<int> UpdateUser(User user)
        {
            return await this.UserRepository.UpdateUser(user);
        }
    }
}
