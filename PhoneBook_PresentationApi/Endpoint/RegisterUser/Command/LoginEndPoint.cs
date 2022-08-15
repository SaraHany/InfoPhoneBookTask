using Ardalis.ApiEndpoints;
using MediatR;
using PhoneBook_Application.features.Registration_User.Command;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook_PresentationApi.Endpoint.RegisterUser.Command
{
    public class LoginEndPoint : EndpointBaseAsync.WithRequest<LoginUserDto>.WithActionResult
    {
        private readonly IMediator _mediator;

        public LoginEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<object> HandleAsync([FromBody] LoginUserDto loginUserDto, CancellationToken cancellationToken)
        //{
        //    var token = await _mediator.Send(loginUserDto);
        //    return token;
        //}

        [HttpPost("/Login")]
        public override async Task<ActionResult> HandleAsync([FromBody] LoginUserDto request, CancellationToken cancellationToken = default)
        {
            var token = await _mediator.Send(request);
            return Ok(token);
        }
    }
}
