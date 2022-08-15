using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList;

namespace PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries
{
    public class GetByIdPhoneBookEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithActionResult<GetPhoneBookDetailsViewModel>
    {
        private readonly IMediator _mediator;

        public GetByIdPhoneBookEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<GetPhoneBookDetailsViewModel> HandleAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var getEventDetailQuery = new GetPhoneBookDetailsQuery() { PhoneBookId = id };
        //    return await _mediator.Send(getEventDetailQuery);
        //}

        [HttpGet("/GetByIdPhoneBook/{id:guid}")]
        public override async Task<ActionResult<GetPhoneBookDetailsViewModel>> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var getEventDetailQuery = new GetPhoneBookDetailsQuery() { PhoneBookId = id };
            return await _mediator.Send(getEventDetailQuery);
        }
    }
}
