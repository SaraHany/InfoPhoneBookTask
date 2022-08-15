using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook_Api;
using PhoneBook_Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Persistence.Repositories
{
    internal class UsersRepository : UsersBaseRepository<Users>, IUsersRepository
    {
        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration config;
        public UsersRepository(UserManager<Users> _userManager, IConfiguration config, PhoneBookDbContext phoneBookDbContext) : base(_userManager, config, phoneBookDbContext)
        {

        }
        public async Task<IReadOnlyList<Users>> GetAllUsersAsync(bool includePhoneBook)
        {
            List<Users> allUsers = new List<Users>();
            allUsers = includePhoneBook ? await _dbContext.users.Include(x => x.PhoneBooks).ToListAsync() : await _dbContext.users.ToListAsync();
            return allUsers;
        }

        public async Task<Users> GetUserByIdAsync(string id, bool includePhoneBook)
        {
            Users user = new Users();
            user = includePhoneBook ? await _dbContext.users.Include(x => x.PhoneBooks).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return user;
        }
    }
}
