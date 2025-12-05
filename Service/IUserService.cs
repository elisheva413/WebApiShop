using Repositeries.Models;

namespace Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        Task<User> LogIn(User user);
        void UpdateUser(int id, User updateUser);
        Task UpdateUser(int id, Entities.User updateUser);
    }
}