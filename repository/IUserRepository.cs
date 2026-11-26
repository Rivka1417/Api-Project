using Entity;

namespace repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(UserLogin userLogin);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}