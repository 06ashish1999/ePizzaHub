using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Services
{
    public class AuthService :Service<User>, IAuthService
    {
        protected readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository):base(userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CreateUser(User user, string role)
        {
            return _userRepository.CreateUser(user, role);
        }

        public UserModel ValidateUser(string email, string password)
        {
            return _userRepository.ValidateUser(email, password);
        }
    }
}
