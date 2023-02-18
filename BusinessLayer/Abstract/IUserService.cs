using Models;
namespace BusinessLayer.Abstract
{
    public interface IUserService 
    {
        List<User> GetUserNamesStartsWith(string letter);
        User GetUserById(int id);
        List<User> AllUsers();
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
