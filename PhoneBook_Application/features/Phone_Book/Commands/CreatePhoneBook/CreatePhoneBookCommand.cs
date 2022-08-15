using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook
{
                                                   //return
    public class CreatePhoneBookCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? PhonNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
