using AutoMapper;
using DTOs;
using Entities;
using Repositeries;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRipository _userRipository;
        IMapper _mapper;

        public UserService(IUserRipository userRipository, IMapper mapper)
        {
            _userRipository = userRipository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<User> users = await _userRipository.GetUsers();
            List<UserDTO>usersDTO =_mapper.Map<List<User>, List < UserDTO >> (users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            User userByID = await _userRipository.GetUserById(id);
            UserDTO userDtoByID= _mapper.Map< User, UserDTO>(userByID);
            return userDtoByID;
        }

        public async Task<UserDTO> AddUser(User user)
        {
            User user1= await _userRipository.AddUser(user);
            UserDTO user1Dto= _mapper.Map<User, UserDTO>(user1);
            return user1Dto;
        }

        public async Task<UserDTO> LogIn(User existingUser)
        {
            User user= await _userRipository.LogIn(existingUser);
            UserDTO userDto= _mapper.Map<User, UserDTO>(user);
            return userDto;

        }

        public async Task UpdateUser(int id, User updateUser)
        {
            await _userRipository.UpdateUser(id, updateUser);
        }
    }
}