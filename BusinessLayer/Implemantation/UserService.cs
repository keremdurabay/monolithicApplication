using BusinessLayer.Interface;
using DataLayer.Implemantation;
using DataLayer.Interface;
using Models;

namespace BusinessLayer.Implemantation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    public async Task<List<UserModel>> AllUsers()
    {
        return await _userRepository.AllUsers();
    }

    public async Task<int> CreateUser(UserModel user)
    {
        return await _userRepository.CreateUser(user);
    }

    public async Task<int> DeleteUser(int id)
    {
        return await _userRepository.DeleteUser(id);
    }

    public async Task<UserModel> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<List<UserModel>> GetUserNamesStartsWith(string letter)
    {
        return (await _userRepository.AllUsers()).Where(user => user.Name.StartsWith(letter)).ToList();
    }

    public async Task<int> UpdateUser(UserModel user)
    {
        return await _userRepository.UpdateUser(user);
    }
}