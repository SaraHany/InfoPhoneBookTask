using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Commands.DeletePhoneBook;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Command
{
    public class DeletePhoneBookEndpoint
    {
        private readonly IMediator _mediator;

        public DeletePhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("/DeletePhoneBook/{id:guid}")]
        [Authorize]
        public async Task<Unit> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var deletePostCommand = new DeletePhoneBookCommand() { PhoneBookId = id };
            await _mediator.Send(deletePostCommand);
            return Unit.Value;
        }
    }
}
