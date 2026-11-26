using Entity;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(UserLogin userLogin);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}