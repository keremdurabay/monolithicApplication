using BusinessLayer.Interface;
using DataLayer.Interface;
using DataLayer.Implemantation;
using Models;
namespace BusinessLayer.Implemantation
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            this._userRepository = new UserRepository();
        }

        public async Task<List<UserModel>> AllUsers()
        {
            return await this._userRepository.AllUsers();
        }

        public async Task<int> CreateUser(UserModel user)
        {
            return await this._userRepository.CreateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await this._userRepository.DeleteUser(id);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await this._userRepository.GetUserById(id);
        }

        public async Task<List<UserModel>> GetUserNamesStartsWith(string letter)
        {
            return (await this._userRepository.AllUsers()).Where(user => user.FirstName.StartsWith(letter)).ToList();
        }

        public async Task<int> UpdateUser(UserModel user)
        {
            return await this._userRepository.UpdateUser(user);
        }

    }
}
