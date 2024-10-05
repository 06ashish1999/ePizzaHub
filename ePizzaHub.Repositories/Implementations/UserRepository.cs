using ePizzaHub.Core;
using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace ePizzaHub.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext):base(appDbContext)
        {
            
        }
        public bool CreateUser(User user, string role)
        {
            try
            {
                Role? _role = _appDbContext.Roles.Where(item => item.Name == role).FirstOrDefault();
                if (_role != null)
                {
                    user.Roles.Add(_role);
                    user.Password = BC.HashPassword(user.Password);

                    _appDbContext.Users.Add(user);
                    _appDbContext.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception ex) { }
            return false;
        }

        public UserModel ValidateUser(string email, string password)
        {
            User? user = _appDbContext.Users.Include(user => user.Roles).Where(user => user.Email == email).FirstOrDefault();
            if (user != null)
            {
                bool isVerified = BC.Verify(password, user.Password);
                if (isVerified)
                {
                    UserModel userModel = new UserModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(role => role.Name).ToArray()
                    };
                    return userModel;
                }
            }
            return null;
        }
    }
}
