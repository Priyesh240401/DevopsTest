using System.Collections.Generic;
using DataAccesLayer.Models;
using SharedLayer.DTOs;

namespace BusinessLayer.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserModel Authenticate(string username, string password);
        UserDto GetUserById(string id);
        UserDto CreateUser(UserDto userDto);
        UserDto UpdateUser(string id, UserDto userDto);
        UserDto DeleteUser(string id);

        UserDto IncrementUserTokens(string userId);

        UserDto DecrementUserTokens(string userId);

    }
}
