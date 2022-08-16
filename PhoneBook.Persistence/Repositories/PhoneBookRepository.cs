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
        public async Task<IReadOnlyList<PhoneBook>> GetAllPhoneBookAsync()
        {
            List<PhoneBook> allPhoneBook = new List<PhoneBook>();
            allPhoneBook = await _dbContext.phoneBook.ToListAsync() /*: await _dbContext.phoneBook.ToListAsync()*/;
            return allPhoneBook;
        }

        public async Task<PhoneBook> GetPhoneBookByIdAsync(Guid id)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook = await _dbContext.phoneBook.FirstOrDefaultAsync(x => x.PhoneBookId == id) /*: await GetByIdAsync(id)*/;
            return phoneBook;
        }
        
        //public async Task<List<PhoneBook>> GetPhoneBookByUserIdAsync(Guid id)
        //{
        //    List<PhoneBook> phoneBook = new List<PhoneBook>();
        //    //phoneBook = await _dbContext.phoneBook.ToListAsync();
        //    //phoneBook = phoneBook.Select();
        //    phoneBook= (List<PhoneBook>)(await (_dbContext.phoneBook).ToListAsync()).Select(x => x.UserId == id);
        //    return phoneBook;
        //}

        public async Task<IReadOnlyList<PhoneBook>> GetPhoneBookByUserIdAsync(string id)
        {
            List<PhoneBook> phoneBook = new List<PhoneBook>();
            //phoneBook = await _dbContext.phoneBook.ToListAsync();
            //phoneBook = phoneBook.Select();
            phoneBook = (List<PhoneBook>)(await(_dbContext.phoneBook).ToListAsync()).Select(x => x.UsersId == id);
            return phoneBook;
        }
    }
}
