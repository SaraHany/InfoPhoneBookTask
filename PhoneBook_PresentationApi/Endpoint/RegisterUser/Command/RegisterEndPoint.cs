using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Registration_User.Command;

namespace PhoneBook_PresentationApi.Endpoint.RegisterUser.Command
{
    public class RegisterEndPoint
    {
        private readonly IMediator _mediator;

        public RegisterEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/Register")]
        public async Task<Unit> HandleAsync([FromBody] RegisterUserDto createPhoneBookCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(createPhoneBookCommand);
            return Unit.Value;
        }
    }
}
