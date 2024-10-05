using ePizzaHub.Core;
using ePizzaHub.Repositories.Implementations;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Contracts;
using ePizzaHub.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // database connection
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            // repositories
            services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), ServiceLifetime.Scoped));

            // services
            services.Add(new ServiceDescriptor(typeof(IAuthService), typeof(AuthService), ServiceLifetime.Scoped));
        }
    }
}
