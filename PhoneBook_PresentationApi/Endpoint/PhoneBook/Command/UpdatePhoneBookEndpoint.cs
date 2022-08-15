using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Commands.UpdatePhoneBook;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Command
{
    public class UpdatePhoneBookEndpoint : EndpointBaseAsync.WithRequest<UpdatePhoneBookCommand>.WithActionResult
    {
        private readonly IMediator _mediator;

        public UpdatePhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<Unit> HandleAsync([FromBody] UpdatePhoneBookCommand updatePhoneBookCommand, CancellationToken cancellationToken)
        //{
        //    await _mediator.Send(updatePhoneBookCommand);
        //    return Unit.Value;
        //}

        [HttpPut("/UpdatePhoneBook")]
        [Authorize]
        public override async Task<ActionResult> HandleAsync([FromBody] UpdatePhoneBookCommand request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
