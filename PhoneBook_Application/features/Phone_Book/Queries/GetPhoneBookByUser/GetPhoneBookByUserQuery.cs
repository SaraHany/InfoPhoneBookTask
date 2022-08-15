using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookByUserID
{
    public class GetPhoneBookByUserQuery : IRequest<List<GetPhoneBookByUserViewModel>>
    {
        public string UserId { get; set; }
    }
}
