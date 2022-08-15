using Microsoft.AspNetCore.Identity;
using PhoneBook_Api;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.Contracts
{
    public interface IUsersRepository : IUserAsyncRepository<Users>
    {
        Task<IReadOnlyList<Users>> GetAllUsersAsync(bool includePhoneBook);
        Task<Users> GetUserByIdAsync(string UserId, bool includePhoneBook);
    }
}
