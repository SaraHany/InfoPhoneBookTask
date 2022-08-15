using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public UsersRepository(PhoneBookDbContext phoneBookDbContext) : base(null, null, phoneBookDbContext)
        {

        }
        public async Task<IReadOnlyList<Users>> GetAllUsersAsync(bool includePhoneBook)
        {
            List<Users> allUsers = new List<Users>();
            allUsers = includePhoneBook ? await _dbContext.users.Include(x => x.PhoneBooks).ToListAsync() : await _dbContext.users.ToListAsync();
            return allUsers;
        }

        public async Task<Users> GetUserByIdAsync(Guid id, bool includePhoneBook)
        {
            Users user = new Users();
            user = includePhoneBook ? await _dbContext.users.Include(x => x.PhoneBooks).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return user;
        }
    }
}
