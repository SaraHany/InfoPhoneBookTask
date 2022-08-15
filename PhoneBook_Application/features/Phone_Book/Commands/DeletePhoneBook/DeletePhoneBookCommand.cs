using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.DeletePhoneBook
{
    public class DeletePhoneBookCommand : IRequest
    {
        //input
        public Guid PhoneBookId { get; set; }
    }
}
