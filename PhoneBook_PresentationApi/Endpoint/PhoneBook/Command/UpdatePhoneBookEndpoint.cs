using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Commands.UpdatePhoneBook;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Command
{
    public class UpdatePhoneBookEndpoint
    {
        private readonly IMediator _mediator;

        public UpdatePhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/UpdatePhoneBook")]
        [Authorize]
        public async Task<Unit> HandleAsync([FromBody] UpdatePhoneBookCommand updatePhoneBookCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(updatePhoneBookCommand);
            return Unit.Value;
        }
    }
}
