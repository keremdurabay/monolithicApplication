using Models;
namespace BusinessLayer.Interface
{
    public interface IUserService 
    {
        Task<List<User>> GetUserNamesStartsWith(string letter);
        Task<User> GetUserById(int id);
        Task<List<User>> AllUsers();
        Task<int> CreateUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);
    }
}
