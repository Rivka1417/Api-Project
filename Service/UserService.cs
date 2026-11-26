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

        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            return repository.AddUser(user);
        }

        public async Task<User> Login(UserLogin userLogin)
        {
            return await repository.Login(userLogin);
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            return await repository.UpdateUser(id, userToUpdate);
        }
    }
}
