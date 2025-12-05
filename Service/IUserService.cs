using Repositeries.Models;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task<User> LogIn(User user);
        Task UpdateUser(int id, Entities.User updateUser);
    }
}