using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList
{
    public class GetPhoneBookListViewModel
    {
        public Guid PhoneBookId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public UsersDTO? User { get; set; }
    }
}
