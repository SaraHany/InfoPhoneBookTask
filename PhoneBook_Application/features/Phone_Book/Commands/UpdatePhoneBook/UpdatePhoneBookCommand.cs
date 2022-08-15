using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.UpdatePhoneBook
{
    public class UpdatePhoneBookCommand : IRequest
    {
        //input
        public Guid PhoneBookId { get; set; }
        //data changed
        public string? Name { get; set; }
        public string? PhonNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
