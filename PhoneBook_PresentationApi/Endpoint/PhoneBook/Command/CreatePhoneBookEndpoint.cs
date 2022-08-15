using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Command
{
    public class CreatePhoneBookEndpoint
    {
        private readonly IMediator _mediator;

        public CreatePhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/CreatePhoneBook")]
        [Authorize]
        public async Task<Guid> HandleAsync([FromBody] CreatePhoneBookCommand createPhoneBookCommand, CancellationToken cancellationToken)
        {
            Guid id = await _mediator.Send(createPhoneBookCommand);
            return id;
        }
    }
}
