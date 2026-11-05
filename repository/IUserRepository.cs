using Entity;

namespace repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int id);
        User Login(UserLogin userLogin);
        User UpdateUser(int id, User userToUpdate);
    }
}