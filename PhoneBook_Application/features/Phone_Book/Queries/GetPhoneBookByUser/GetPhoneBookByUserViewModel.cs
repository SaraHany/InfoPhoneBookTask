using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookByUserID
{
    public class GetPhoneBookByUserViewModel
    {
        public Guid PhoneBookId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UsersId { get; set; }
    }
}
