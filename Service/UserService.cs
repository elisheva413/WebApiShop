using Repositeries;
using Repositeries.Models;
using Service;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRipository _userRipository;

        public UserService(IUserRipository userRipository)
        {
            _userRipository = userRipository;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRipository.GetUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRipository.GetUserById(id);
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRipository.AddUser(user);
        }

        public async Task<User> LogIn(User user)
        {
            return await _userRipository.LogIn(user);
        }

        public async Task UpdateUser(int id, User updateUser)
        {
            await _userRipository.UpdateUser(id, updateUser);
        }
    }
}