using PhoneBook_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.Contracts.Persistence
{
    public interface IPhoneBookRepository : IAsyncRepository<PhoneBook>
    {
        Task<IReadOnlyList<PhoneBook>> GetAllPhoneBookAsync(/*bool includeUsers*/);
        Task<PhoneBook> GetPhoneBookByIdAsync(Guid PhoneBookId/*, bool includeUsers*/);
        Task<IReadOnlyList<PhoneBook>> GetPhoneBookByUserIdAsync(string UserId/*, bool includeUsers*/);
    }
}
