using Microsoft.EntityFrameworkCore;
using PhoneBook_Api;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Persistence.Repositories
{
    public class PhoneBookRepository : BaseRepository<PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(PhoneBookDbContext phoneBookDbContext) : base(phoneBookDbContext)
        {

        }
        public async Task<IReadOnlyList<PhoneBook>> GetAllPhoneBookAsync(bool includeUser)
        {
            List<PhoneBook> allPhoneBook = new List<PhoneBook>();
            allPhoneBook = includeUser ? await _dbContext.phoneBook.Include(x => x.User).ToListAsync() : await _dbContext.phoneBook.ToListAsync();
            return allPhoneBook;
        }

        public async Task<PhoneBook> GetPhoneBookByIdAsync(Guid id, bool includeUser)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook = includeUser ? await _dbContext.phoneBook.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return phoneBook;
        }
    }
}
