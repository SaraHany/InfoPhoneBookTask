using MediatR;
using PhoneBook_Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.Registration_User.Query
{
    public class UserLoginHandlerInput : BaseRequest, IRequest<UserLoginHandlerOutput>
    {
        public UserLoginHandlerInput() { }
        UserLoginHandlerInput(Guid id) : base(/*correlationId*/) { }
    }
}
