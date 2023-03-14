using Models;
namespace BusinessLayer.Interface
{
    public interface IUserService 
    {
        Task<List<UserModel>> GetUserNamesStartsWith(string letter);
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> AllUsers();
        Task<int> CreateUser(UserModel user);
        Task<int> UpdateUser(UserModel user);
        Task<int> DeleteUser(int id);
    }
}
