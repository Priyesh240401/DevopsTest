using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Models;
using DataAccessLayer;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }

        public UserModel GetUserByUsernameAndPassword(string username, string password)
        {
            // Implementation to get a user by username and password from the database
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public UserModel GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserModel AddUser(UserModel user)
        {


            user.Id = Guid.NewGuid().ToString();
           


            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel UpdateUser(UserModel user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public UserModel DeleteUser(string id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }
}
