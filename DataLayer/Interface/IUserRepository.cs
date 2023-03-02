using Models;
namespace DataLayer.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<List<User>> AllUsers();
        Task<int> CreateUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);


    }
}
