using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Core.Messages
{
    public abstract class BaseRequest : BaseMessage
    {
        public BaseRequest()
        { }

        public BaseRequest(Guid correlationId) : base()
        {
            base._correlationId = correlationId;
        }
    }
}
