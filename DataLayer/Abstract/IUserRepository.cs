using Models;
namespace DataLayer.Abstract
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> AllUsers();
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);


    }
}
