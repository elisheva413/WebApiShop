using Repositeries;
using Entities;
using DTOs;

namespace Service
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> AddUser(User user);
        Task<UserDTO> LogIn(User user);
        Task UpdateUser(int id, User updateUser);
       
    }
}