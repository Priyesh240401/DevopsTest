using BusinessLayer.IServices;
using DataAccesLayer.Models;
using DataAccessLayer.IRepository;
using SharedLayer.DTOs;
using System.Collections.Generic;


namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return MapToUserDtoList(users);
        }

        public UserDto GetUserById(string id)
        {
            var user = _userRepository.GetUserById(id);
            return MapToUserDto(user);
        }

        public UserDto IncrementUserTokens(string userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            user.TokensAvailable++;
            _userRepository.UpdateUser(user);

            return MapToUserDto(user);
        }

        public UserDto DecrementUserTokens(string userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null || user.TokensAvailable <= 0)
            {
                return null;
            }

            user.TokensAvailable--;
            _userRepository.UpdateUser(user);

            return MapToUserDto(user);
        }
        public UserModel Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByUsernameAndPassword(username, password);

            if (user == null)
            {
                return null; 
            }

            return user; 
        }


        public UserDto CreateUser(UserDto userDto)
        {
            var userEntity = MapToUserEntity(userDto);
            var createdUser = _userRepository.AddUser(userEntity);
            return MapToUserDto(createdUser);
        }

        public UserDto UpdateUser(string id, UserDto userDto)
        {
            var existingUser = _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return null; 
            }

            existingUser.Name = userDto.Name;
            existingUser.Username = userDto.Username;
            existingUser.Password = userDto.Password;
            existingUser.TokensAvailable = userDto.TokensAvailable;

            var updatedUser = _userRepository.UpdateUser(existingUser);
            return MapToUserDto(updatedUser);
        }

        public UserDto DeleteUser(string id)
        {
            var deletedUser = _userRepository.DeleteUser(id);
            return MapToUserDto(deletedUser);
        }

        private UserDto MapToUserDto(UserModel user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                TokensAvailable = user.TokensAvailable
                
            };
        }

        
        private List<UserDto> MapToUserDtoList(IEnumerable<UserModel> users)
        {
            var userDtoList = new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = MapToUserDto(user);
                userDtoList.Add(userDto);
            }
            return userDtoList;
        }

        
        private UserModel MapToUserEntity(UserDto userDto)
        {
            return new UserModel
            {
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password,
                TokensAvailable = userDto.TokensAvailable
               
            };
        }
    }
}
