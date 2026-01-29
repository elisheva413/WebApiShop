using AutoMapper;
using DTOs;
using Entities;
using Repositories;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            List<User> users = await _userRepository.GetUsers();
            List<UserDTO>usersDTO =_mapper.Map<List<User>, List < UserDTO >> (users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            User userByID = await _userRepository.GetUserById(id);
            if (userByID == null)
                return null;
            UserDTO userDtoByID= _mapper.Map< User, UserDTO>(userByID);
            return userDtoByID;
        }

        public async Task<UserDTO> AddUser(UserRegisterDTO newUser)
        {
            User userRegister = _mapper.Map<UserRegisterDTO, User>(newUser);
            User user = await _userRepository.AddUser(userRegister);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> LogIn(UserLoginDTO existingUser)
        {
            User loginUser = _mapper.Map<UserLoginDTO, User>(existingUser);
            User user= await _userRepository.LogIn(loginUser);
            UserDTO userDto= _mapper.Map<User, UserDTO>(user);
            return userDto;

        }

        public async Task UpdateUser(int id, UserDTO updateUser)
        {
            User user=_mapper.Map <UserDTO, User>(updateUser);
            await _userRepository.UpdateUser(id, user);
        }
    }
}