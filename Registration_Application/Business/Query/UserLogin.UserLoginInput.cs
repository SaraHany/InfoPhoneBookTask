using MediatR;
using Registration_Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_Application.Business.Query
{
    public class UserLoginHandlerInput : BaseRequest, IRequest<UserLoginHandlerOutput>
    {
        public UserLoginHandlerInput() { }
        UserLoginHandlerInput(Guid id) : base(/*correlationId*/) { }
    }
}
