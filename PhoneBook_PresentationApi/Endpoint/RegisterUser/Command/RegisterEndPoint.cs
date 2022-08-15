using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Registration_User.Command;

namespace PhoneBook_PresentationApi.Endpoint.RegisterUser.Command
{
    public class RegisterEndPoint : EndpointBaseAsync.WithRequest<RegisterUserDto>.WithActionResult
    {
        private readonly IMediator _mediator;

        public RegisterEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<Unit> HandleAsync([FromBody] RegisterUserDto createPhoneBookCommand, CancellationToken cancellationToken)
        //{
        //    await _mediator.Send(createPhoneBookCommand);
        //    return Unit.Value;
        //}

        [HttpPost("/Register")]
        public override async Task<ActionResult> HandleAsync([FromBody] RegisterUserDto request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
