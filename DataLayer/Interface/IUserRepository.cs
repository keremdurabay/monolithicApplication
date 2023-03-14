using Models;
namespace DataLayer.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> AllUsers();
        Task<int> CreateUser(UserModel user);
        Task<int> UpdateUser(UserModel user);
        Task<int> DeleteUser(int id);

    }
}
