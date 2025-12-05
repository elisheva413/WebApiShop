using Repositeries.Models;

namespace Repositeries
{
    public interface IUserRipository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task<User> LogIn(User user);
        Task UpdateUser(int id, User updateUser);
    }
}

