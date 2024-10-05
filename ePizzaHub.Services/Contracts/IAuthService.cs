using ePizzaHub.Core.Entities;
using ePizzaHub.Models;


namespace ePizzaHub.Services.Contracts
{
    public interface IAuthService:IService<User>
    {
        bool CreateUser(User user, string role);
        UserModel ValidateUser(string email, string password);
    }
}
