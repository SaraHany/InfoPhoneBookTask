using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails
{
                                                      //return
    public class GetPhoneBookDetailsQuery : IRequest<GetPhoneBookDetailsViewModel>
    {
        public Guid PhoneBookId { get; set; }
    }
}
