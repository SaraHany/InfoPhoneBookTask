using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Commands.DeletePhoneBook;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Command
{
    public class DeletePhoneBookEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithActionResult
    {
        private readonly IMediator _mediator;

        public DeletePhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<ActionResult<Unit>> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var deletePostCommand = new DeletePhoneBookCommand() { PhoneBookId = id };
        //    await _mediator.Send(deletePostCommand);
        //    return Unit.Value;
        //}

        [HttpDelete("/DeletePhoneBook/{id:guid}")]
        //[Authorize]
        public override async Task<ActionResult> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var deletePostCommand = new DeletePhoneBookCommand() { PhoneBookId = id };
            await _mediator.Send(deletePostCommand);
            return Ok();
        }
    }
}
