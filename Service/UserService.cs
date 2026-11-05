using System.Text.Json;
using repository;
using Entity;
namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            return repository.AddUser(user);
        }

        public User Login(UserLogin userLogin)
        {
            return repository.Login(userLogin);
        }

        public User UpdateUser(int id, User userToUpdate)
        {
            return repository.UpdateUser(id, userToUpdate);
        }
    }
}
