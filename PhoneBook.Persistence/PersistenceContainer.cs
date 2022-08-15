using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook_Api;
using PhoneBook_Application.Contracts;
using PhoneBook_Application.Contracts.Persistence;
using PhoneBook_Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoneBookDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PhoneBookConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPhoneBookRepository), typeof(PhoneBookRepository));
            services.AddScoped(typeof(IUsersRepository), typeof(UsersRepository));
            services.AddScoped(typeof(IUserAsyncRepository<>), typeof(UsersBaseRepository<>));
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<PhoneBookDbContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
