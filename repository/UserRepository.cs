using System.Text.Json;
using Entity;
using Microsoft.EntityFrameworkCore;
using repository.Entity;
namespace repository
{
    public class UserRepository : IUserRepository
    {
        MyStoreContext _dbContext;

        public UserRepository(MyStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserById(int id)
        {
            

            User user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;

        }

        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public async Task<User> Login(UserLogin userLogin)
        {
            
            User user = await _dbContext.Users.Where(u=>u.Email==userLogin.Email&&u.Password==userLogin.Password).FirstOrDefaultAsync();
            if (user == null)
                return null;
            return user;
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            User user=await _dbContext.Users.FindAsync(id);
            if (user == null)
                return null;
            _dbContext.Entry(user).CurrentValues.SetValues(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
