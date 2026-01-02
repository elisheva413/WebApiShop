using Repositeries;
using Entities;
using DTOs;

namespace Service
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> AddUser(UserRegisterDTO user);
        Task<UserDTO> LogIn(UserLoginDTO user);
        Task UpdateUser(int id, UserDTO updateUser);
       
    }
}