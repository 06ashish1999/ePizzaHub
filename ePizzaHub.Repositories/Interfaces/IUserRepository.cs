using ePizzaHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePizzaHub.Models;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        bool CreateUser(User user, string role);
        UserModel ValidateUser(string email, string password);
    }
}
