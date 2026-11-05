using Entity;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User user);
        User GetUserById(int id);
        User Login(UserLogin userLogin);
        User UpdateUser(int id, User userToUpdate);
    }
}