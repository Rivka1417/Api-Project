using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Entity;
using repository;
namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        private IPasswordService passwordService;

        public UserService(IUserRepository repository, IPasswordService passwordService)
        {
            this.repository = repository;
            this.passwordService = passwordService;
        }

        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }

        public User AddUser(User user)
        {
            if (this.passwordService.CheckPasswordStrength(user.Password) < 2)
                throw new ValidationException("The password is too weak");
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
