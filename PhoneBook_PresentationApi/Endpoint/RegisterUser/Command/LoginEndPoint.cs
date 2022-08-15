using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Registration_User.Command;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace PhoneBook_PresentationApi.Endpoint.RegisterUser.Command
{
    public class LoginEndPoint
    {
        private readonly IMediator _mediator;

        public LoginEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/Login")]
        public async Task<object> HandleAsync([FromBody] LoginUserDto loginUserDto, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(loginUserDto);
            return token;
        }
    }
}
