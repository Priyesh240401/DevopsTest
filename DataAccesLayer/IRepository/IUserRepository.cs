using DataAccesLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserById(string id);
        UserModel GetUserByUsernameAndPassword(string username, string password);
        UserModel AddUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        UserModel DeleteUser(string id);
    }
}
