using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails;
using Ardalis.ApiEndpoints;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Command
{
    //[Route("Api/")]
    public class CreatePhoneBookEndpoint : EndpointBaseAsync.WithRequest<CreatePhoneBookCommand>.WithActionResult<Guid>
    {
        private readonly IMediator _mediator;

        public CreatePhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<Guid> HandleAsync([FromBody] CreatePhoneBookCommand createPhoneBookCommand, CancellationToken cancellationToken)
        //{
        //    Guid id = await _mediator.Send(createPho
        //}neBookCommand);
        //    return id;

        [HttpPost("/CreatePhoneBook")]
        [Authorize]
        public override async Task<ActionResult<Guid>> HandleAsync([FromBody] CreatePhoneBookCommand request, CancellationToken cancellationToken = default)
        {
            //Guid id = 
            return await _mediator.Send(request);
        }
    }
}
